# AI Programming Log

Project:** StellarExplorer1  
AI system:** Llama 3.2 3B Instruct  
AI integration:** AI Studio extension in Visual Studio

This document records the AI-assisted programming work completed during the development of the StellarExplorer1 assignment. It includes the prompts submitted, the AI responses, any generated code, and explanations of how the suggestions were used or modified.

Feature 1 – Star Chart

1.1 Star class implementation
### 1.1 Star Class Implementation (`Star.cs`)

| Item | Details |
|---|---|
| **Feature** | Feature 1 – Star Chart |
| **Task** | Create the `Star.cs` model class |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Purpose** | To create a model class representing individual stars in the application. |

**Original AI Prompt**

```text
I am developing a WPF desktop application named StellarExplorer1 using C# and .NET 10.

I am currently implementing Feature 1 – Star Chart.

Help me create a C# model class named Star.cs.

It must contain these properties:

- int Id
- string Name
- double Distance
- double X
- double Y
- double Z
- double Magnitude
- string Spect

Requirements:
1. Use public properties with getters and setters.
2. Use PascalCase naming.
3. Include XML documentation comments for the class and every property.
4. Give string properties appropriate default values to avoid nullable warnings.
5. Do not create additional classes.
6. Do not modify any other files.

Return the complete C# code and briefly explain each property.
```

**Complete AI Response – Generated Code**

```csharp
using System;

/// <summary>
/// Represents a star in the StellarExplorer1 application.
/// </summary>
public class Star
{
    /// <summary>
    /// Unique identifier for the star.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the star.
    /// </summary>
    public string Name { get; set; } = "Unknown";

    /// <summary>
    /// Average distance from Earth to the star in astronomical units (AU).
    /// </summary>
    public double Distance { get; set; }

    /// <summary>
    /// X-coordinate of the star's position in a 3D space.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Y-coordinate of the star's position in a 3D space.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Z-coordinate of the star's position in a 3D space.
    /// </summary>
    public double Z { get; set; }

    /// <summary>
    /// Apparent magnitude of the star as seen from Earth.
    /// </summary>
    public double Magnitude { get; set; }

    /// <summary>
    /// Spectral type of the star (e.g., O, B, A, F, G, K, M).
    /// </summary>
    public string Spect { get; set; } = "Unknown";
}
```

**AI Response – Property Explanations**

- `Id`: Unique identifier for the star.
- `Name`: Name of the star. Defaults to `"Unknown"`.
- `Distance`: Average distance from Earth to the star in astronomical units (AU).
- `X`: X-coordinate of the star's position in 3D space.
- `Y`: Y-coordinate of the star's position in 3D space.
- `Z`: Z-coordinate of the star's position in 3D space.
- `Magnitude`: Apparent magnitude of the star as seen from Earth.
- `Spect`: Spectral type of the star, such as O, B, A, F, G, K or M. Defaults to `"Unknown"`.

**Implementation and Explanation**

The AI generated a `Star` model class containing the eight requested public properties. The class uses appropriate C# data types: `int` for the identifier, `string` for the star name and spectral type, and `double` for numerical astronomical data and 3D coordinates.

XML documentation comments were included for the class and every property. The string properties were assigned the default value `"Unknown"` to avoid nullable reference warnings.

The generated class provides a common data structure for storing information about individual stars. It is used by the application when loading and managing star catalogue records.

**Developer Review and Testing**

The generated code was reviewed and used as the basis for the `Star.cs` model class. The implementation was subsequently organised under the `StellarExplorer1.Models` namespace.

The class was kept separate from other application components, following the single-responsibility approach requested in the prompt.

**Outcome:** The `Star.cs` model class was implemented for Feature 1 and used as the foundation for loading and displaying star catalogue data.

**Reflection**

Using the AI assistant helped generate the initial model structure and XML documentation quickly. I reviewed the generated code and integrated it into the project's existing namespace and structure.

1.2 Star collection and CSV loading

### 1.2 StarCollection Class Design

| Item | Details |
|---|---|
| **Feature** | Feature 1 – Star Chart |
| **Task** | Design the responsibilities and methods of the `StarCollection` class |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Related class** | `Star.cs` |
| **Data format** | CSV (Comma Separated Values) |
| **Purpose** | Plan how star catalogue records would be loaded, organised and accessed by the application. |

**Original AI Prompt**

```text
I am developing StellarExplorer1, a WPF desktop application using C# and .NET 10.

I have already created:
- Models/Star.cs
- Models/StarCollection.cs

The Star class contains:
Id, Name, Distance, X, Y, Z, Magnitude and Spect.

Help me design the StarCollection class for Feature 1 – Star Chart.

The assignment requires:

1. Loading at least 2,000 real star records from a local data file.
2. Reading and managing Star objects.
3. Supporting catalogue designations for stars without proper names.
4. Making the star collection accessible to other parts of the application.

For now:
- Explain the responsibilities and proposed methods of StarCollection.
- Recommend a suitable local data format (CSV is acceptable).
- Explain how missing star names should be handled.
- Explain how the class should interact with Star.cs.
- Do not generate code.
- Do not modify any files.

Keep the design suitable for a beginner-level C# WPF project.
```

**Complete AI Response**

The `StarCollection` class will be responsible for loading, managing, and providing access to a collection of `Star` objects. Its primary responsibilities include:

1. Loading star data from a local CSV file.
2. Reading and parsing the CSV file into a list of `Star` objects.
3. Managing the list of loaded stars (e.g., adding, removing, searching).
4. Providing a catalog-style interface for retrieving stars by designation.

**Proposed Methods**

- `LoadStarsFromCsv(string filePath)`: Loads star data from a specified CSV file and returns a list of `Star` objects.
- `AddStar(Star star)`: Adds a new `Star` object to the collection.
- `RemoveStar(int id)`: Removes a `Star` object by its ID.
- `GetStarById(int id)`: Retrieves a `Star` object by its ID.
- `GetStarsByDesignation(string designation)`: Returns a list of `Star` objects matching the specified catalog designation (e.g., "Sirius", "Alpha Centauri").

**Recommended Local Data Format**

A suitable local data format for this project is CSV (Comma Separated Values). CSV files are widely supported and easy to work with, making them an excellent choice for storing star data.

**Handling Missing Star Names**

To handle stars without proper names, you can use catalog designations as a fallback. For example:

- If a star's name is missing, use its designation (e.g., "Alpha Centauri") as the display name.
- You can also consider using placeholder names or generic labels for unidentified stars.

**Interaction with `Star.cs`**

The `StarCollection` class should interact with the `Star` class as follows:

- The `Star` class will contain properties that match the CSV file's column headers (e.g., `Id`, `Name`, `Distance`, etc.).
- The `StarCollection` class will load a list of `Star` objects from the CSV file and manage them accordingly.
- When retrieving stars, the `StarCollection` class will use the `Star` class to access the star's data.

By following this design, you'll be able to create an efficient and accessible `StarCollection` class that complements your `Star` model and supports the catalog-style interface required for Feature 1 – Star Chart.

**Developer Review and Implementation Decisions**

The proposed design provided an initial plan for separating star data management from the WPF user interface.

During implementation, the following decisions were made:

1. The CSV file `bigstarchart.csv` was selected as the local data source.
2. The existing `Star` model was reused to represent each record.
3. The collection was stored in a `List<Star>`.
4. Catalogue designations were used when proper star names were unavailable.
5. The implemented class provided `GetLoadedStars()` to make the loaded collection accessible to other parts of the application.

The initial design proposed additional methods for adding, removing and searching stars. These were design suggestions and were not all implemented in the final class.

**Outcome**

The design established the responsibilities of `StarCollection` before its implementation. It helped guide the development of the CSV-loading functionality and the integration between `StarCollection.cs` and `Star.cs`.

**Reflection**

The AI assistant helped me plan the structure of the data-management class before writing code. This made it easier to understand the responsibilities of each class and keep the project organised. I then adapted the proposed design to the actual requirements of the application.

## 1.3 StarCollection Implementation (`StarCollection.cs`)

| **Item** | **Details** |
|---|---|
| **Feature** | Feature 1 – Star Chart |
| **Task** | Implement CSV loading and create a collection of `Star` objects |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Data source** | `bigstarchart.csv` |
| **Data records** | 2,000 star records |
| **Purpose** | Load the star catalogue, parse its data and provide access to the loaded stars. |

**Original AI Prompt**

```text
I am developing StellarExplorer1, a WPF desktop application using C# and .NET 10.

I have a Star class in the StellarExplorer1.Models namespace with the following properties:

Id, Name, Distance, X, Y, Z, Magnitude and Spect.

I want to implement the StarCollection class to load star data from my local CSV file, bigstarchart.csv.

The CSV file contains 2,000 star records and 37 columns.

Help me implement the StarCollection class.

The implementation should:
1. Read the CSV file.
2. Skip the header row.
3. Parse each valid record into a Star object.
4. Use the correct CSV column indexes for the star properties.
5. Use a proper star name when available.
6. If a proper name is unavailable, use available catalogue designations as fallback names.
7. Handle invalid or missing numerical values safely.
8. Use invariant culture when parsing numerical values.
9. Avoid creating another Star class.
10. Make the loaded stars accessible to other parts of the application.

Return the complete C# code and explain the implementation.
```

**AI Response – Implementation Approach**

The AI assistant suggested creating a `StarCollection` class that stores the loaded stars in a `List<Star>`. It proposed reading the CSV file, skipping the header, parsing the individual columns and creating a `Star` object for each valid record.

It also suggested using catalogue identifiers when a proper star name was unavailable and using `double.TryParse` to avoid errors when parsing numerical values.

**Generated Code Review and Debugging**

The first generated implementation required several corrections before it could be used successfully.

The following issues were identified during the review:

- The required `System.IO` namespace was missing.
- The CSV loop condition could omit the final data record.
- The proper-name column index was incorrect.
- Some catalogue fallback names were not handled correctly.
- The spectral type fallback logic was incorrect.
- Some generated code contained syntax and variable-scope errors.
- The implementation needed to check that a CSV row contained enough columns before accessing its values.
- Invalid star IDs needed to be skipped rather than assigned an arbitrary value.

I submitted follow-up prompts asking the AI assistant to correct these issues. The revised code was checked again before being integrated into the project.

**Final Implemented Code – `StarCollection.cs`**

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace StellarExplorer1.Models
{
    /// <summary>
    /// Represents a collection of stars loaded from a CSV file.
    /// </summary>
    public class StarCollection
    {
        private List<Star> _stars = new List<Star>();

        public StarCollection(string csvFilePath)
        {
            LoadStarsFromCsv(csvFilePath);
        }

        public List<Star> GetLoadedStars()
        {
            return _stars;
        }

        private void LoadStarsFromCsv(string csvFilePath)
        {
            string[] lines = File.ReadAllLines(csvFilePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                if (values.Length < 37)
                    continue;

                if (!int.TryParse(values[0], out int id))
                    continue;

                Star star = new Star
                {
                    Id = id,
                    Name = GetProperNameOrDesignation(values, id),

                    Distance = double.TryParse(
                        values[9],
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double distance) ? distance : 0.0,

                    Magnitude = double.TryParse(
                        values[13],
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double magnitude) ? magnitude : 0.0,

                    Spect = string.IsNullOrWhiteSpace(values[15])
                        ? "Unknown"
                        : values[15].Trim(),

                    X = double.TryParse(
                        values[17],
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double x) ? x : 0.0,

                    Y = double.TryParse(
                        values[18],
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double y) ? y : 0.0,

                    Z = double.TryParse(
                        values[19],
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double z) ? z : 0.0
                };

                _stars.Add(star);
            }
        }

        private string GetProperNameOrDesignation(
            string[] values,
            int id)
        {
            if (!string.IsNullOrWhiteSpace(values[6]))
                return values[6].Trim();

            if (!string.IsNullOrWhiteSpace(values[1]))
                return $"HIP-{values[1].Trim()}";

            if (!string.IsNullOrWhiteSpace(values[2]))
                return $"HD-{values[2].Trim()}";

            if (!string.IsNullOrWhiteSpace(values[3]))
                return $"HR-{values[3].Trim()}";

            if (!string.IsNullOrWhiteSpace(values[4]))
                return $"Gl-{values[4].Trim()}";

            if (!string.IsNullOrWhiteSpace(values[29]))
                return $"Bayer-{values[29].Trim()}";

            if (!string.IsNullOrWhiteSpace(values[30]))
                return $"Flamsteed-{values[30].Trim()}";

            return $"STAR-{id}";
        }
    }
}
```

**Implementation Explanation**

The final implementation performs the following operations:

1. Reads all lines from `bigstarchart.csv` using `File.ReadAllLines()`.
2. Starts at index `1` to skip the CSV header.
3. Splits each row into individual values.
4. Checks that each row contains at least 37 columns.
5. Uses `int.TryParse()` to validate the star ID and skips records with invalid IDs.
6. Uses `double.TryParse()` with `CultureInfo.InvariantCulture` to parse numerical values.
7. Creates a `Star` object for each valid record.
8. Adds each object to the `_stars` collection.
9. Provides `GetLoadedStars()` so other application components can access the loaded stars.

The `GetProperNameOrDesignation()` method checks for a proper name first. If one is unavailable, it checks the available catalogue identifiers in the following order:

- HIP
- HD
- HR
- Gl
- Bayer
- Flamsteed
- Generated `STAR-` identifier as the final fallback.

**Developer Review and Testing**

The final code was integrated into the existing `StellarExplorer1.Models` namespace and used the previously created `Star` class.

The application was built successfully, and the CSV loading functionality was tested.

<ins>Test result:</ins> The application successfully loaded **2,000 stars** from `bigstarchart.csv`.

**Outcome**

The `StarCollection` class successfully loads and manages the star records required by Feature 1. It also provides fallback names for stars without proper names, allowing the application to identify and display catalogue entries.

**Reflection**

The AI assistant helped generate the initial CSV-loading implementation. However, the first versions contained several errors involving column indexes, missing namespaces, loop conditions and fallback logic. I reviewed the generated code, identified the problems and used follow-up prompts to improve it. This process helped me understand CSV parsing, data validation, object creation and the importance of testing AI-generated code before using it in a project.

---

## 1.4 Feature 2 – Initial 3D Viewport Setup Using HelixToolkit

| **Item** | **Details** |
|---|---|
| **Feature** | Feature 2 – Visualising the Star Chart |
| **Task** | Create an interactive 3D viewport |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Framework** | WPF with .NET 10 |
| **Library** | HelixToolkit.Wpf 3.1.2 |
| **File** | `MainWindow.xaml` |
| **Purpose** | Set up the 3D viewing area for displaying and exploring stars. |

**Original AI Prompt**

```text
I am developing a WPF desktop application named StellarExplorer1 using C# and .NET 10.

I have installed the NuGet package HelixToolkit.Wpf version 3.1.2.

I am now implementing Feature 2 – Visualising the Star Chart.

My MainWindow.xaml file currently contains an empty WPF window.

Help me create the initial 3D viewport using HelixToolkit.

Requirements:
1. Use the correct HelixToolkit WPF XML namespace.
2. Add a HelixViewport3D inside the main Grid.
3. Allow the standard mouse controls for rotating, zooming and panning the 3D view.
4. Include a coordinate system visualisation.
5. Include suitable lighting.
6. Do not add any stars yet.
7. Do not write any C# code.
8. Return the complete XAML file.
9. Briefly explain the components.

Make sure the XAML is suitable for HelixToolkit.Wpf 3.1.2.
```

**Complete AI Response – Initial Generated XAML**

```xml
<Window x:Class="StellarExplorer1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:StellarExplorer1"
        xmlns:hv="clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.Wpf"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">

    <Grid>
        <hv:HelixViewport3D x:Name="vp3D"
                            MouseUp="vp3D_MouseUp"
                            MouseDown="vp3D_MouseDown"
                            MouseWheel="vp3D_MouseWheel">

            <!-- Coordinate system visualization -->
            <hv:CoordinateSystem />

            <!-- Directional light -->
            <hv:DirectionalLight Color="#FF000000"
                                 Position="0,0,0.1" />

        </hv:HelixViewport3D>
    </Grid>
</Window>
```

**AI Response – Explanation**

The AI assistant explained that:

- The `hv` XML namespace provides access to HelixToolkit WPF controls.
- `HelixViewport3D` provides the interactive 3D viewing area.
- The coordinate system provides a visual reference for the 3D axes.
- Lighting is included to illuminate 3D objects.
- The viewport supports mouse-based camera interaction.

**Developer Review and Implementation Decisions**

The generated XAML was reviewed before being used. Some elements needed reconsideration:

- The generated mouse event handlers would require corresponding C# methods, even though the prompt requested XAML only.
- The generated directional light used a black colour, which would not provide useful illumination.
- The coordinate-system element and other HelixToolkit elements needed to be checked against the installed library version.

I subsequently used a simpler viewport setup with `DefaultLights`, which provides standard lighting for the 3D scene.

**Final Implemented XAML**

The following is the XAML used in the application:

```xml
<Window x:Class="StellarExplorer1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:hv="clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.Wpf"
        mc:Ignorable="d"
        Title="Stellar Explorer - 3D Star Chart"
        Height="600"
        Width="1000"
        Background="Black">

    <Grid Background="Black">

        <hv:HelixViewport3D x:Name="viewport"
                            Background="Black">

            <hv:DefaultLights />

        </hv:HelixViewport3D>

        <CheckBox x:Name="ShowAllStarsCheckBox"
                  Content="Show all stars"
                  IsChecked="True"
                  Foreground="White"
                  FontSize="14"
                  Margin="15"
                  HorizontalAlignment="Left"
                  VerticalAlignment="Top" />

    </Grid>
</Window>
```

**Implementation Explanation**

The final XAML creates a black 3D viewport using `HelixViewport3D`. The `DefaultLights` element provides lighting for objects displayed in the scene.

The window dimensions were increased to provide more room for the star chart. A `CheckBox` named `ShowAllStarsCheckBox` was also added. This control is used by the C# code to allow the user to show or filter catalogue entries without proper star names.

The viewport provides the foundation for displaying the star collection as 3D points and adding camera navigation functionality.

**Developer Review and Testing**

The XAML was integrated into `MainWindow.xaml` and tested in Visual Studio.

The application built successfully and opened with the 3D viewport displayed. The initial viewport was subsequently extended with C# code to render stars, display their names and support navigation.

**Outcome**

The initial HelixToolkit viewport was successfully integrated into StellarExplorer1. It provided the 3D environment needed for the remaining Feature 2 implementation.

**Reflection**

The AI assistant helped me understand how to integrate HelixToolkit into a WPF application using XAML. However, I did not use every part of the generated code unchanged. I reviewed the lighting and event-handler configuration and adapted the viewport to suit the project. This demonstrated the importance of checking AI-generated XAML against the actual library and application requirements.

---

Feature 2 – 3D Visualising the Star Chart

2.1 Rendering stars in 3D

2.2 Displaying star names

2.3 Spectral class colours

2.4 Filtering stars without proper names

2.5 Mouse and keyboard navigation

2.6 Testing and debugging

---

Feature 3 – 3D Movement

(To be completed)

---

Feature 4 – Additional Facilities

(To be completed)
