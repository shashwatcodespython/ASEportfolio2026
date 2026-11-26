
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using StellarExplorer1.Models;

namespace StellarExplorer1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Star> _stars = new List<Star>();

        private readonly List<Visual3D> _starVisuals =
            new List<Visual3D>();

        private bool _isCatalogueLoaded = false;

        // Camera navigation settings.
        private PerspectiveCamera? _camera;

        private const double CameraMoveSpeed = 5.0;

        public MainWindow()
        {
            InitializeComponent();

            // Respond to changes in the star filter checkbox.
            ShowAllStarsCheckBox.Checked +=
                ShowAllStarsCheckBox_Changed;

            ShowAllStarsCheckBox.Unchecked +=
                ShowAllStarsCheckBox_Changed;

            // Handle keyboard navigation.
            PreviewKeyDown += MainWindow_PreviewKeyDown;

            // Load the stars after the window has loaded.
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStars();

            // Get the existing perspective camera.
            _camera = viewport.Camera as PerspectiveCamera;

            if (_camera == null)
            {
                MessageBox.Show(
                    "The 3D viewport does not have a PerspectiveCamera.",
                    "Camera Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void LoadStars()
        {
            try
            {
                string filePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "bigstarchart.csv");

                if (!File.Exists(filePath))
                {
                    MessageBox.Show(
                        $"Star catalogue file not found:\n{filePath}",
                        "File Not Found",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);

                    return;
                }

                // Load the star collection.
                StarCollection starCollection =
                    new StarCollection(filePath);

                _stars = starCollection.GetLoadedStars();

                _isCatalogueLoaded = true;

                // Display the stars using the current filter setting.
                DisplayStars(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while loading the star catalogue:\n{ex.Message}",
                    "Loading Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        // Rebuilds the star chart according to the checkbox setting.
        private void DisplayStars(bool zoomToExtents)
        {
            try
            {
                // Remove previously displayed star visuals.
                foreach (Visual3D visual in _starVisuals)
                {
                    viewport.Children.Remove(visual);
                }

                _starVisuals.Clear();

                // Create separate visual collections for each spectral class.
                PointsVisual3D oStars = CreateStarVisual(Colors.Blue);

                PointsVisual3D bStars = CreateStarVisual(
                    Color.FromRgb(170, 210, 255));

                PointsVisual3D aStars = CreateStarVisual(Colors.White);

                PointsVisual3D fStars = CreateStarVisual(
                    Color.FromRgb(255, 240, 180));

                PointsVisual3D gStars = CreateStarVisual(Colors.Yellow);

                PointsVisual3D kStars = CreateStarVisual(Colors.Orange);

                PointsVisual3D mStars = CreateStarVisual(Colors.Red);

                PointsVisual3D unknownStars = CreateStarVisual(Colors.Gray);

                bool showAllStars =
                    ShowAllStarsCheckBox.IsChecked == true;

                int displayedCount = 0;
                int namedStarCount = 0;

                List<Star> displayedStars = new List<Star>();

                // Assign stars to their spectral-class collections.
                foreach (Star star in _stars)
                {
                    if (!HasValidCoordinates(star))
                    {
                        continue;
                    }

                    bool hasProperName = HasProperName(star.Name);

                    // Hide unnamed stars when the filter is unchecked.
                    if (!showAllStars && !hasProperName)
                    {
                        continue;
                    }

                    Point3D point = new Point3D(
                        star.X,
                        star.Y,
                        star.Z);

                    string spectralClass =
                        star.Spect?.Trim().ToUpperInvariant() ?? "";

                    if (spectralClass.Length == 0)
                    {
                        unknownStars.Points.Add(point);
                    }
                    else
                    {
                        switch (spectralClass[0])
                        {
                            case 'O':
                                oStars.Points.Add(point);
                                break;

                            case 'B':
                                bStars.Points.Add(point);
                                break;

                            case 'A':
                                aStars.Points.Add(point);
                                break;

                            case 'F':
                                fStars.Points.Add(point);
                                break;

                            case 'G':
                                gStars.Points.Add(point);
                                break;

                            case 'K':
                                kStars.Points.Add(point);
                                break;

                            case 'M':
                                mStars.Points.Add(point);
                                break;

                            default:
                                unknownStars.Points.Add(point);
                                break;
                        }
                    }

                    displayedStars.Add(star);
                    displayedCount++;

                    if (hasProperName)
                    {
                        namedStarCount++;
                    }
                }

                // Add the coloured star collections to the viewport.
                AddStarVisual(oStars);
                AddStarVisual(bStars);
                AddStarVisual(aStars);
                AddStarVisual(fStars);
                AddStarVisual(gStars);
                AddStarVisual(kStars);
                AddStarVisual(mStars);
                AddStarVisual(unknownStars);

                // Add labels for stars with genuine proper names.
                foreach (Star star in displayedStars)
                {
                    if (!HasProperName(star.Name))
                    {
                        continue;
                    }

                    BillboardTextVisual3D label =
                        new BillboardTextVisual3D
                        {
                            Text = star.Name.Trim(),

                            Position = new Point3D(
                                star.X,
                                star.Y,
                                star.Z),

                            Foreground = Brushes.White,
                            Background = Brushes.Transparent,
                            FontSize = 12
                        };

                    AddStarVisual(label);
                }

                // Update the application title.
                Title = $"Stellar Explorer - {displayedCount} Stars | " +
                        $"{namedStarCount} Named Stars";

                // Zoom to all stars only during the initial display.
                if (zoomToExtents)
                {
                    viewport.ZoomExtents();
                }

                if (displayedCount == 0)
                {
                    MessageBox.Show(
                        "No stars match the current filter.",
                        "No Stars Found",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while displaying the stars:\n{ex.Message}",
                    "Display Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        // Adds a visual to the viewport and tracks it for later removal.
        private void AddStarVisual(Visual3D visual)
        {
            viewport.Children.Add(visual);
            _starVisuals.Add(visual);
        }

        // Handles changes to the star filter checkbox.
        private void ShowAllStarsCheckBox_Changed(
            object sender,
            RoutedEventArgs e)
        {
            if (_isCatalogueLoaded)
            {
                DisplayStars(false);
            }
        }

        // Handles keyboard navigation using the camera's local directions.
        private void MainWindow_PreviewKeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (_camera == null)
            {
                return;
            }

            Vector3D forward = _camera.LookDirection;

            if (forward.LengthSquared < 0.000001)
            {
                return;
            }

            forward.Normalize();

            Vector3D right = Vector3D.CrossProduct(
                forward,
                _camera.UpDirection);

            if (right.LengthSquared < 0.000001)
            {
                return;
            }

            right.Normalize();

            Vector3D localUp = Vector3D.CrossProduct(
                right,
                forward);

            localUp.Normalize();

            Vector3D movement;

            switch (e.Key)
            {
                case Key.W:
                    movement = forward;
                    break;

                case Key.S:
                    movement = -forward;
                    break;

                case Key.A:
                    movement = -right;
                    break;

                case Key.D:
                    movement = right;
                    break;

                case Key.Q:
                    movement = localUp;
                    break;

                case Key.E:
                    movement = -localUp;
                    break;

                default:
                    return;
            }

            // Move the camera without changing its orientation.
            _camera.Position += movement * CameraMoveSpeed;

            e.Handled = true;
        }

        // Creates a visual collection with the specified colour.
        private PointsVisual3D CreateStarVisual(Color color)
        {
            return new PointsVisual3D
            {
                Color = color,
                Size = 6
            };
        }

        // Checks whether the star has valid 3D coordinates.
        private bool HasValidCoordinates(Star star)
        {
            return double.IsFinite(star.X) &&
                   double.IsFinite(star.Y) &&
                   double.IsFinite(star.Z);
        }

        // Identifies genuine proper names and excludes catalogue identifiers.
        private bool HasProperName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            string trimmedName = name.Trim();

            if (trimmedName.Equals(
                "Unknown",
                StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            string[] cataloguePrefixes =
            {
                "HIP-",
                "HD-",
                "HR-",
                "Gl-",
                "Bayer-",
                "Flamsteed-",
                "STAR-"
            };

            foreach (string prefix in cataloguePrefixes)
            {
                if (trimmedName.StartsWith(
                    prefix,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
