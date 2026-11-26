
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

        /// <summary>
        /// Initializes a new instance of the StarCollection class.
        /// </summary>
        /// <param name="csvFilePath">The path to the CSV file.</param>
        public StarCollection(string csvFilePath)
        {
            LoadStarsFromCsv(csvFilePath);
        }

        /// <summary>
        /// Returns the list of loaded stars.
        /// </summary>
        /// <returns>The list of loaded stars.</returns>
        public List<Star> GetLoadedStars()
        {
            return _stars;
        }

        /// <summary>
        /// Loads star records from the CSV file.
        /// </summary>
        /// <param name="csvFilePath">The path to the CSV file.</param>
        private void LoadStarsFromCsv(string csvFilePath)
        {
            string[] lines = File.ReadAllLines(csvFilePath);

            // Skip the first line because it contains the CSV headers.
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                // Check that the row contains all required columns.
                if (values.Length < 37)
                {
                    continue;
                }

                // Read the star ID. Skip the row if the ID is invalid.
                if (!int.TryParse(values[0], out int id))
                {
                    continue;
                }

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

        /// <summary>
        /// Gets the proper name or an available catalogue designation.
        /// </summary>
        /// <param name="values">The CSV row values.</param>
        /// <param name="id">The star ID.</param>
        /// <returns>A proper name or catalogue designation.</returns>
        private string GetProperNameOrDesignation(string[] values, int id)
        {
            // Use the proper name if available.
            if (!string.IsNullOrWhiteSpace(values[6]))
            {
                return values[6].Trim();
            }

            // Otherwise, use an available catalogue designation.
            if (!string.IsNullOrWhiteSpace(values[1]))
            {
                return $"HIP-{values[1].Trim()}";
            }

            if (!string.IsNullOrWhiteSpace(values[2]))
            {
                return $"HD-{values[2].Trim()}";
            }

            if (!string.IsNullOrWhiteSpace(values[3]))
            {
                return $"HR-{values[3].Trim()}";
            }

            if (!string.IsNullOrWhiteSpace(values[4]))
            {
                return $"Gl-{values[4].Trim()}";
            }

            if (!string.IsNullOrWhiteSpace(values[29]))
            {
                return $"Bayer-{values[29].Trim()}";
            }

            if (!string.IsNullOrWhiteSpace(values[30]))
            {
                return $"Flamsteed-{values[30].Trim()}";
            }

            // Use a stable fallback if no designation is available.
            return $"STAR-{id}";
        }
    }
}
