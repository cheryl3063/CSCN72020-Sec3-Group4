using System;
using System.IO;

namespace SmartAquariumController
{
    /// <summary>
    /// Simple temperature sensor simulation for the Smart Aquarium Controller.
    /// Reads a value from "temperature.txt" and exposes helpers to interpret it.
    /// </summary>
    public class TemperatureSensor
    {
        private readonly string _filePath;

        /// <summary>
        /// Last temperature value read (in °C).
        /// </summary>
        public double CurrentTemperature { get; private set; }

        /// <summary>
        /// Recommended safe range for the fish (you can tweak these later).
        /// </summary>
        public double MinSafeTemperature { get; } = 22.0;
        public double MaxSafeTemperature { get; } = 28.0;

        public TemperatureSensor()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temperature.txt");

            // If the file doesn't exist yet, create it with a default value.
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "25"); // default 25 °C
            }

            // Initialize with whatever is currently in the file.
            Update();
        }

        /// <summary>
        /// Reads the latest temperature value from the text file.
        /// </summary>
        public void Update()
        {
            try
            {
                string text = File.ReadAllText(_filePath).Trim();

                if (double.TryParse(text, out double value))
                {
                    CurrentTemperature = value;
                }
                else
                {
                    // If parsing fails, fall back to a safe default.
                    CurrentTemperature = 25.0;
                }
            }
            catch
            {
                // If something goes wrong (file locked, missing, etc.),
                // fall back to a safe default so the app never crashes.
                CurrentTemperature = 25.0;
            }
        }

        /// <summary>
        /// Returns true if the current temperature is inside the safe range.
        /// </summary>
        public bool IsInSafeRange()
        {
            return CurrentTemperature >= MinSafeTemperature &&
                   CurrentTemperature <= MaxSafeTemperature;
        }

        /// <summary>
        /// Returns a friendly status message that you can show on the UI later.
        /// </summary>
        public string GetStatusMessage()
        {
            if (IsInSafeRange())
            {
                return $"Temperature: {CurrentTemperature:F1} °C (within safe range)";
            }

            if (CurrentTemperature < MinSafeTemperature)
            {
                return $"Temperature: {CurrentTemperature:F1} °C (too cold – increase heater)";
            }

            return $"Temperature: {CurrentTemperature:F1} °C (too warm – consider cooling)";
        }

        public override string ToString()
        {
            return $"Temperature: {CurrentTemperature:F1} °C";
        }
    }
}
