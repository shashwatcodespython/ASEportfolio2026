# AI Programming Log

Project:** StellarExplorer1  
AI system:** Llama 3.2 3B Instruct  
AI integration:** AI Studio extension in Visual Studio

This document records the AI-assisted programming work completed during the development of the StellarExplorer1 assignment. It includes the prompts submitted, the AI responses, any generated code, and explanations of how the suggestions were used or modified.

Feature 1 – Star Chart

1.1 Star class implementation
| Item | Details |
|---|---|
| **Date** |10/27/2026 |
| **Feature** |A new star.cs file |
| **Task** |To create a new star.cs file |
| **AI system** | Llama 3.2 3B Instruct |
| **AI prompt** |I am developing a WPF desktop application named StellarExplorer1 using C# and .NET 10. I am currently implementing Feature 1 – Star Chart. Help me create a C# model class named Star.cs. It must contain these properties:- int Id - string Name - double Distance - double X - double Y - double Z - double Magnitude - string Spect
Requirements:
1. Use public properties with getters and setters.
2. Use PascalCase naming.
3. Include XML documentation comments for the class and every property.
4. Give string properties appropriate default values to avoid nullable warnings.
5. Do not create additional classes.
6. Do not modify any other files.

Return the complete C# code and briefly explain each property.
 |
| **AI response** |Each property is explained as follows:

- `Id`: Unique identifier for the star.
- `Name`: Name of the star. Defaults to "Unknown".
- `Distance`: Average distance from Earth to the star in astronomical units (AU).
- `X`, `Y`, and `Z`: X, Y, and Z coordinates of the star's position in a 3D space.
- `Magnitude`: Apparent magnitude of the star as seen from Earth.
- `Spect`: Spectral type of the star (e.g., O, B, A, F, G, K, M). Defaults to "Unknown".
 |
| **Generated code** | using System;

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
|
| **Code explanation** | |
| **Changes made** | |
| **Testing and result** | |

1.2 Star collection and CSV loading

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
