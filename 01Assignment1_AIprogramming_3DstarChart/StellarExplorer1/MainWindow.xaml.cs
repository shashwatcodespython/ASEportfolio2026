
using System;
using System.IO;
using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();

            // Load the stars after the window has loaded.
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStars();
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
                StarCollection starCollection = new StarCollection(filePath);
                var stars = starCollection.GetLoadedStars();

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

                int displayedCount = 0;
                int namedStarCount = 0;

                // Assign each star to its spectral-class collection.
                foreach (Star star in stars)
                {
                    if (!HasValidCoordinates(star))
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

                    displayedCount++;
                }

                // Add the coloured star collections to the viewport.
                viewport.Children.Add(oStars);
                viewport.Children.Add(bStars);
                viewport.Children.Add(aStars);
                viewport.Children.Add(fStars);
                viewport.Children.Add(gStars);
                viewport.Children.Add(kStars);
                viewport.Children.Add(mStars);
                viewport.Children.Add(unknownStars);

                // Add labels for stars with genuine proper names.
                foreach (Star star in stars)
                {
                    if (!HasValidCoordinates(star) ||
                        !HasProperName(star.Name))
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

                    viewport.Children.Add(label);
                    namedStarCount++;
                }

                // Update the application title.
                Title = $"Stellar Explorer - {displayedCount} Stars | " +
                        $"{namedStarCount} Named Stars";

                // Adjust the camera to display all stars.
                viewport.ZoomExtents();

                if (displayedCount == 0)
                {
                    MessageBox.Show(
                        "No valid star coordinates were found.",
                        "No Stars Found",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
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
