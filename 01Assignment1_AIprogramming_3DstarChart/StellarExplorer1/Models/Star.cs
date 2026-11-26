
namespace StellarExplorer1.Models;

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
    /// Name or catalogue designation of the star.
    /// </summary>
    public string Name { get; set; } = "Unknown";

    /// <summary>
    /// Distance of the star from Earth.
    /// The unit depends on the source dataset.
    /// </summary>
    public double Distance { get; set; }

    /// <summary>
    /// X-coordinate of the star's position in 3D space.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Y-coordinate of the star's position in 3D space.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Z-coordinate of the star's position in 3D space.
    /// </summary>
    public double Z { get; set; }

    /// <summary>
    /// Apparent magnitude of the star as seen from Earth.
    /// </summary>
    public double Magnitude { get; set; }

    /// <summary>
    /// Spectral class of the star (O, B, A, F, G, K or M).
    /// </summary>
    public string Spect { get; set; } = "Unknown";
}
