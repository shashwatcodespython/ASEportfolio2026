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

## 1.5 Refining the HelixToolkit 3D Viewport

| **Item** | **Details** |
|---|---|
| **Feature** | Feature 2 – Visualising the Star Chart |
| **Task** | Refine the initial 3D viewport and add a coordinate system |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Library** | HelixToolkit.Wpf 3.1.2 |
| **File** | `MainWindow.xaml` |
| **Purpose** | Configure the viewport with lighting, a coordinate system and standard camera controls. |

**Original AI Prompt**

```text
I am developing a WPF desktop application called StellarExplorer1 using C# and .NET 10.

The NuGet package HelixToolkit.Wpf version 3.1.2 is already installed.

My current MainWindow.xaml is:

<Window x:Class="StellarExplorer1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:StellarExplorer1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
    </Grid>
</Window>

TASK:

Return the complete revised MainWindow.xaml that creates a basic 3D viewport using HelixToolkit.Wpf 3.1.2.

Requirements:
1. Declare the correct HelixToolkit XML namespace.
2. Add a HelixViewport3D inside the existing Grid.
3. Add DefaultLights.
4. Add CoordinateSystemVisual3D.
5. Allow standard HelixToolkit mouse rotation, zooming and panning.
6. Do not add mouse event handlers or require any changes to MainWindow.xaml.cs.
7. Do not add stars or CSV loading yet.
8. Keep the code compatible with HelixToolkit.Wpf 3.1.2.

Explain the changes briefly.
```

**Complete AI Response – Generated XAML**

```xml
<Window x:Class="StellarExplorer1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:hv="clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.Wpf"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <hv:HelixViewport3D x:Name="viewport" DefaultLights="True" CoordinateSystemVisual3D="{Binding}" MouseMoveEnabled="True" />
    </Grid>
</Window>
```

**AI Response – Explanation**

The AI assistant explained that:

1. The `hv` XML namespace provides access to HelixToolkit controls.
2. `HelixViewport3D` creates the main 3D viewing area.
3. The `DefaultLights` property enables default lighting.
4. `CoordinateSystemVisual3D` provides a visual coordinate system.
5. Mouse interaction is intended to support rotation, zooming and panning.

**Developer Review and Corrections**

The generated XAML required further review. Although the response described the required components, it did not correctly demonstrate how to add `DefaultLights` and `CoordinateSystemVisual3D` as visual elements inside the viewport.

The response also used `CoordinateSystemVisual3D="{Binding}"`, which was not the correct way to add the coordinate-system visual.

The intended structure was to place the lighting and coordinate-system elements inside `HelixViewport3D` as child elements. The viewport's standard mouse interaction did not require manually adding mouse event handlers.

**Final Implementation Decision**

The application was subsequently configured with `HelixViewport3D` and `DefaultLights`. The final viewport was kept simple so that the star-rendering functionality could be implemented separately.

**Outcome**

The AI-generated XAML provided a starting point for understanding the HelixToolkit viewport. Its incorrect property usage was identified during review, and the viewport was adapted before further development.

**Reflection**

This task demonstrated that AI-generated XAML should not be accepted without checking the actual structure and supported properties of the installed library. I learned to distinguish between properties and visual elements that need to be placed inside a viewport.

---

## 1.6 First Version of 3D Star Rendering

| **Item** | **Details** |
|---|---|
| **Feature** | Feature 2 – Visualising the Star Chart |
| **Task** | Load the star catalogue and render stars as 3D points |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Library** | HelixToolkit.Wpf 3.1.2 |
| **Files** | `MainWindow.xaml.cs`, `Star.cs`, `StarCollection.cs` |
| **Purpose** | Display the loaded star catalogue in the 3D viewport. |

**Original AI Prompt**

```text
I am developing a WPF application called StellarExplorer1 using C# and .NET 10.

I have installed HelixToolkit.Wpf version 3.1.2.

My project already contains:
- Models/Star.cs
- Models/StarCollection.cs
- MainWindow.xaml
- MainWindow.xaml.cs
- bigstarchart.csv

The CSV file has its Build Action set to Content and Copy to Output Directory set to Copy if newer.

My current MainWindow.xaml contains:

<Window x:Class="StellarExplorer1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:hv="clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.Wpf"
        mc:Ignorable="d"
        Title="Stellar Explorer - 3D Star Chart"
        Height="600"
        Width="1000">

    <Grid>
        <hv:HelixViewport3D x:Name="viewport">
            <hv:DefaultLights />
            <hv:CoordinateSystemVisual3D />
        </hv:HelixViewport3D>
    </Grid>
</Window>

The Star class is in namespace StellarExplorer1.Models and has these properties:

- Id
- Name
- Distance
- X
- Y
- Z
- Magnitude
- Spect

The StarCollection class is also in namespace StellarExplorer1.Models. It has a constructor accepting a CSV file path and a method called GetLoadedStars() that returns List<Star>.

TASK:

Implement the first version of 3D star rendering by revising MainWindow.xaml.cs.

Requirements:

1. Load the CSV using StarCollection.
2. Find the CSV file in the application's output directory using AppDomain.CurrentDomain.BaseDirectory.
3. Use HelixToolkit's PointsVisual3D to represent the stars.
4. Convert each star's X, Y and Z coordinates into a System.Windows.Media.Media3D.Point3D.
5. Display all successfully loaded stars in the existing HelixViewport3D named viewport.
6. Use a single visible colour for all stars for now.
7. Set an appropriate point size so the stars can be seen.
8. Update the window title to display the number of loaded stars.
9. Handle a missing CSV file gracefully with a clear error message.
10. Keep the implementation compatible with WPF and HelixToolkit.Wpf 3.1.2.

Do not modify Star.cs, StarCollection.cs or MainWindow.xaml.

Return the complete revised MainWindow.xaml.cs file and briefly explain the implementation.
```

**Complete AI Response – Generated Code**

```csharp
using System;
using System.IO;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace StellarExplorer1
{
    public partial class MainWindow : Window
    {
        private StarCollection _starCollection = null;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bigstarchart.csv");
                var starsLoaded = new List<Star>();

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The CSV file '{filePath}' does not exist.");
                }

                _starCollection = new StarCollection(filePath);
                starsLoaded = _starCollection.GetLoadedStars();

                PointSize = 1.0;
                Title = $"Stellar Explorer - {starsLoaded.Count} Stars";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the CSV file: {ex.Message}");
                Environment.Exit(1);
            }

            var pointsVisual3D = new PointsVisual3D
            {
                Colors = Brushes.White,
                PointSize = 0.2f
            };

            foreach (var star in starsLoaded)
            {
                Media3D.Point3D point = new Media3D.Point3D(star.X, star.Y, star.Z);
                pointsVisual3D.Points.Add(point);
            }

            viewport.Content = pointsVisual3D;
        }
    }
}
```

**AI Response – Explanation**

The AI assistant explained that the implementation:

- Uses `AppDomain.CurrentDomain.BaseDirectory` to locate the CSV file in the output directory.
- Uses `StarCollection` to load the star records.
- Uses `PointsVisual3D` to represent stars in the viewport.
- Converts each star's coordinates into a `Point3D`.
- Uses white as the initial colour for the stars.
- Updates the window title with the number of loaded stars.
- Displays an error message if the CSV file cannot be found.

**Developer Review and Identified Problems**

The generated code contained several problems and could not be used unchanged.

The following issues were identified:

1. The `System.Windows` namespace was missing, which is needed for `Window` and `MessageBox`.
2. The `System.Collections.Generic` namespace was missing for `List<Star>`.
3. The `StellarExplorer1.Models` namespace was missing for `Star` and `StarCollection`.
4. The variable `starsLoaded` was declared inside the `try` block but used outside it.
5. `PointSize` was assigned directly, rather than being set on the `PointsVisual3D` object.
6. `Brushes` was used without importing `System.Windows.Media`.
7. The code used `Media3D.Point3D` even though the relevant namespace had already been imported.
8. The code assigned `viewport.Content`, which needed to be checked against the actual viewport structure and existing XAML.

These issues showed that the AI response was not a complete, directly compilable implementation.

**Developer Review and Implementation Decisions**

The generated code was used as a starting point for understanding how to render the stars with HelixToolkit.

The implementation was subsequently developed and tested in the existing project. The CSV-loading functionality was retained, and the star coordinates were converted into 3D points for display.

The existing viewport and camera interaction were kept separate from the star-loading logic.

**Testing**

The application was built and tested in Visual Studio. The star catalogue was successfully loaded, and the stars were displayed in the 3D chart.

**Outcome**

The first version of 3D star rendering established the connection between the `StarCollection` data and the HelixToolkit viewport.

**Reflection**

The AI assistant helped identify the relevant HelixToolkit visual class and the general process for converting catalogue coordinates into 3D points. However, the generated code contained namespace, variable-scope and property-usage errors. Reviewing and correcting these errors helped me understand how WPF code-behind interacts with XAML and how 3D visual objects are added to the viewport.

---

## 1.7 Implementing Spectral-Class Colours

| **Item** | **Details** |
|---|---|
| **Feature** | Feature 2 – Visualising the Star Chart |
| **Task** | Apply different colours to stars according to their spectral classes |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Library** | HelixToolkit.Wpf 3.1.2 |
| **File** | `MainWindow.xaml.cs` |
| **Purpose** | Make the different stellar spectral classes visually distinguishable. |

**Original AI Prompt**

```text
I have a working WPF 3D star chart using HelixToolkit.Wpf 3.1.2 and .NET 10.

My application successfully loads 2,000 stars from bigstarchart.csv and displays them using PointsVisual3D.

I want to implement spectral-class colouring.

Requirements:
1. O-type stars: Blue.
2. B-type stars: Blue-white.
3. A-type stars: White.
4. F-type stars: Yellow-white.
5. G-type stars: Yellow.
6. K-type stars: Orange.
7. M-type stars: Red.
8. Unknown or missing spectral classes: Grey.

Please examine my existing MainWindow.xaml.cs implementation and suggest the simplest beginner-friendly way to implement this using HelixToolkit.Wpf.

Important:
- Preserve the existing CSV loading functionality.
- Preserve the existing 3D camera controls.
- Do not change Star.cs or StarCollection.cs.
- Avoid unnecessary classes or complicated architecture.
- Explain the proposed changes before providing the complete revised MainWindow.xaml.cs.

I will review the code before using it.
```

**Complete AI Response – Proposed Changes**

To implement spectral-class coloring, we'll introduce a new `StarColor` enum and modify the existing `StarCollection` class to return a custom `Star` object with an added color property.

1. **Enum for Star Colors:** We will define an enum `StarColors` in `MainWindow.xaml.cs` to represent the different spectral classes.
2. **Custom Star Object:** The existing `Star` class will remain unchanged, but we'll create a new custom version of it (`CustomStar`) that includes the color property.

**Generated Code**

```csharp
using System;
using System.IO;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace StellarExplorer1
{
    public partial class MainWindow : Window
    {
        private StarCollection _starCollection = null;

        // Enum for Star Colors
        public enum StarColors { O, B, A, F, G, K, M, Unknown };

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bigstarchart.csv");
                var starsLoaded = new List<CustomStar>();

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The CSV file '{filePath}' does not exist.");
                }

                _starCollection = new StarCollection(filePath);
                starsLoaded = _starCollection.GetLoadedStars();

                PointSize = 1.0;
                Title = $"Stellar Explorer - {starsLoaded.Count} Stars";

                // Map spectral class to color
                foreach (var star in starsLoaded)
                {
                    switch ((StarColors)Enum.Parse(typeof(StarColors), star.Spectral))
                    {
                        case StarColors.O:
                            star.Color = Brushes.Blue;
                            break;
                        case StarColors.B:
                            star.Color = Brushes.BlueWhite;
                            break;
                        case StarColors.A:
                            star.Color = Brushes.White;
                            break;
                        case StarColors.F:
                            star.Color = Brushes.YellowWhite;
                            break;
                        case StarColors.G:
                            star.Color = Brushes.Yellow;
                            break;
                        case StarColors.K:
                            star.Color = Brushes.Orange;
                            break;
                        case StarColors.M:
                            star.Color = Brushes.Red;
                            break;
                        default:
                            star.Color = Brushes.Gray;
                            break;
                    }
                }

                var pointsVisual3D = new PointsVisual3D
                {
                    Colors = Brushes.White,
                    PointSize = 0.2f
                };

                foreach (var star in starsLoaded)
                {
                    Media3D.Point3D point = new Media3D.Point3D(star.X, star.Y, star.Z);
                    pointsVisual3D.Points.Add(new Point3DCollection(new[] { point }));
                }

                // Add custom colors to visual
                pointsVisual3D.Colors.Add(starCollection.GetColors());

                viewport.Content = pointsVisual3D;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the CSV file: {ex.Message}");
                Environment.Exit(1);
            }
        }

        // Custom Star class with added color property
        public class CustomStar
        {
            public double Id { get; set; }
            public string Name { get; set; }
            public double Distance { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public string Spect { get; set; } // spectral class
            public Brush Color { get; set; }
        }

        private Brush[] GetColors()
        {
            var colors = new Brush[StarCollection.Instance.StarCount];

            for (int i = 0; i < StarCollection.Instance.StarCount; i++)
            {
                if (StarCollection.Instance.GetSpectralClass(i) == StarColors.O)
                    colors[i] = Brushes.Blue;
                else if (StarCollection.Instance.GetSpectralClass(i) == StarColors.B)
                    colors[i] = Brushes.BlueWhite;
                else if (StarCollection.Instance.GetSpectralClass(i) == StarColors.A)
                    colors[i] = Brushes.White;
                else if (StarCollection.Instance.GetSpectralClass(i) == StarColors.F)
                    colors[i] = Brushes.YellowWhite;
                else if (StarCollection.Instance.GetSpectralClass(i) == StarColors.G)
                    colors[i] = Brushes.Yellow;
                else if (StarCollection.Instance.GetSpectralClass(i) == StarColors.K)
                    colors[i] = Brushes.Orange;
                else if (StarCollection.Instance.GetSpectralClass(i) == StarColors.M)
                    colors[i] = Brushes.Red;
                else
                    colors[i] = Brushes.Gray;
            }

            return colors;
        }
    }
}
```

**AI Response – Explanation**

The AI assistant proposed introducing an enum for the spectral classes and a custom star class containing an additional colour property. It then suggested assigning colours based on each star's spectral class using a `switch` statement.

The proposed colour mapping was:

| **Spectral class** | **Suggested colour** |
|---|---|
| O | Blue |
| B | Blue-white |
| A | White |
| F | Yellow-white |
| G | Yellow |
| K | Orange |
| M | Red |
| Unknown | Grey |

**Developer Review and Identified Problems**

The generated response did not correctly follow the requirements of the prompt.

The following issues were identified:

1. It introduced a `CustomStar` class even though the existing `Star` class already contained all required properties.
2. It attempted to assign `List<Star>` to `List<CustomStar>`, which is not a valid assignment.
3. It referred to `star.Spectral`, although the existing property is named `Spect`.
4. It used `Brushes.BlueWhite` and `Brushes.YellowWhite`, which are not standard predefined WPF brushes.
5. It used an undefined `starCollection` variable.
6. It referred to `StarCollection.Instance`, `StarCount` and `GetSpectralClass()`, which were not part of the existing `StarCollection` implementation.
7. It attempted to use `PointsVisual3D.Colors` as though it were a brush collection. This was not the correct approach for the intended implementation.
8. It did not correctly preserve the existing collection and rendering structure.

**Developer Review and Implementation Decisions**

The proposed custom class and additional enum were unnecessary for this application.

The existing `Star.Spect` property already contains the spectral classification. Therefore, the simpler approach was to determine a colour from that property when rendering the stars.

The implementation was subsequently organised around the existing star collection and HelixToolkit point visuals. The spectral classes were assigned the required colours without modifying `Star.cs` or `StarCollection.cs`.

**Testing**

The application was built and tested after the spectral-colour implementation. The stars were displayed using different colours according to their spectral classes, with grey used for unknown classifications.

**Outcome**

Spectral-class colouring was added to the 3D star chart. This made the different types of stars easier to distinguish visually.

**Reflection**

The AI assistant initially proposed an unnecessarily complicated solution that introduced additional classes and referenced properties and methods that did not exist in the project. Reviewing the code helped me recognise that the existing `Spect` property was sufficient. I chose a simpler implementation that preserved the existing data model and avoided unnecessary changes to other files.

---

## 1.8 Planning the Display of Star Names

| **Item** | **Details** |
|---|---|
| **Feature** | Feature 2 – Visualising the Star Chart |
| **Task** | Plan how to display star names next to their 3D positions |
| **AI system** | Llama 3.2 3B Instruct |
| **AI integration** | AI Studio extension in Visual Studio |
| **Library** | HelixToolkit.Wpf 3.1.2 |
| **File to be revised** | `MainWindow.xaml.cs` |
| **Purpose** | Display star names while avoiding excessive labels in the 3D chart. |

**Original AI Prompt**

```text
My WPF application StellarExplorer1 currently:
- Loads 2,000 stars from bigstarchart.csv.
- Displays stars in a HelixToolkit.Wpf 3D viewport.
- Uses different colours for O, B, A, F, G, K and M spectral classes.
- Supports mouse rotation and zoom.

I want to implement the next Feature 2 requirement: displaying star names in the 3D star chart.

Requirements:
1. Display star names next to their corresponding 3D star positions.
2. Use the existing Star.Name property.
3. Avoid making the chart overcrowded with 2,000 labels.
4. Preserve spectral-class colouring.
5. Preserve existing mouse rotation and zoom functionality.
6. Use HelixToolkit.Wpf 3.1.2 and .NET 10.
7. Do not modify Star.cs or StarCollection.cs unless absolutely necessary.

First explain your proposed implementation and which HelixToolkit classes you recommend.

Do not provide revised code yet. I want to review the approach first.
```

**Complete AI Response – Proposed Implementation**

To implement the star names display feature without overcrowding the chart, we'll use a combination of techniques:

1. **Label Overlap Reduction:** We can rotate the labels slightly away from their corresponding stars to reduce overlap. This is achievable using HelixToolkit's built-in `LabelPlacement` property or by manually adjusting label positions.
2. **Scatter Label Placement:** Instead of placing labels directly at star positions, we'll use a scatter placement strategy for labels, allowing them to be positioned around the stars without overlapping.

To achieve these goals while preserving existing spectral-class coloring and mouse rotation/zoom functionality:

- We will utilize HelixToolkit's `Label` class as the base for our custom label control. This class is designed specifically for 3D labeling in HelixToolkit.
- We'll create a custom subclass of `Label`, named `StarLabel`, to enhance its features. This custom label will be used to display star names and will inherit behavior from the original `Label` class.
- To avoid cluttering the chart, we'll implement a technique called "scatter labeling," where labels are placed at a specified distance from their corresponding stars along a plane.

**Recommended HelixToolkit Classes**

The AI assistant recommended:

- `HelixToolkit.Wpf.Label`: Described as a base class for custom 3D labels.
- `HelixToolkit.Wpf.LabelPlacement`: Described as a property for controlling label placement.
- `HelixToolkit.Wpf.Point3D`: Described as the class used to position the labels.

**Developer Review and Evaluation**

The suggested approach required further investigation before implementation.

The response did not provide a clear, verified explanation of how these proposed classes and properties would work with the installed HelixToolkit.Wpf 3.1.2 package.

In particular:

1. The response did not establish that `Label` and `LabelPlacement` were appropriate, available APIs for this implementation.
2. It proposed creating a custom `StarLabel` class, although the requirement was to avoid unnecessary additional classes.
3. It did not explain how the suggested scatter-placement technique would be implemented.
4. It did not provide a practical method for limiting the number of labels displayed.
5. It did not demonstrate how the proposed labels would remain associated with their corresponding 3D star positions.

**Developer Implementation Decision**

Rather than immediately implementing the suggested custom label system, I considered a simpler approach using the existing `Star.Name` property and HelixToolkit's 3D text visual functionality.

The aim was to display proper star names while avoiding unnecessary labels for stars that only had generated catalogue designations.

This approach would allow the chart to retain its spectral-class colours and existing camera controls.

**Outcome**

The AI assistant provided an initial discussion of possible label-placement techniques. However, its recommendations were not sufficiently verified or detailed to use directly. Further implementation and testing were required to achieve the star-name display requirement.

**Reflection**

This task showed that AI-generated technical recommendations should be checked against the actual library API. The assistant suggested classes and properties without demonstrating that they were suitable for the installed package. I therefore evaluated the suggestions instead of implementing them immediately. This helped me focus on a simpler solution that fitted the existing application structure and avoided unnecessary custom classes.

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
