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

1.3 Star catalogue naming

1.4 Testing and debugging

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
