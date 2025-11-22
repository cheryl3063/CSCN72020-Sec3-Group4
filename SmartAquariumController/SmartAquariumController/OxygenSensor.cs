using System;
using System.IO;

namespace SmartAquariumController
{
    /// <summary>
    /// Simple oxygen level sensor simulation for the Smart Aquarium Controller.
    /// Reads a value from "oxygen.txt" and provides status helpers.
    /// </summary>
    public class OxygenSensor
    {
        private readonly string _filePath;

        /// <summary>
        /// Last oxygen level read (mg/L).
        /// </summary>
        public double CurrentOxygen { get; private set; }

        /// <summary>
        /// Recommended safe range for aquarium oxygen levels.
        /// </summary>
        public double MinSafeOxygen { get; } = 5.0;  // mg/L
        public double MaxSafeOxygen { get; } = 10.0; // mg/L

        public OxygenSensor()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "oxygen.txt");

            // Create default file if missing
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "6.5"); // Default safe oxygen level
            }

            Update();
        }

        /// <summary>
        /// Reads the oxygen level from the simulation file.
        /// </summary>
        public void Update()
        {
            try
            {
                string text = File.ReadAllText(_filePath).Trim();

                if (double.TryParse(text, out double value))
                {
                    CurrentOxygen = value;
                }
                else
                {
                    CurrentOxygen = 6.5;
                }
            }
            catch
            {
                CurrentOxygen = 6.5;
            }
        }

        /// <summary>
        /// Returns whether the oxygen level is in the safe range.
        /// </summary>
        public bool IsInSafeRange()
        {
            return CurrentOxygen >= MinSafeOxygen &&
                   CurrentOxygen <= MaxSafeOxygen;
        }

        /// <summary>
        /// Returns a friendly status message.
        /// </summary>
        public string GetStatus()
        {
            if (IsInSafeRange())
                return $"Oxygen Level: {CurrentOxygen:F1} mg/L (safe)";

            if (CurrentOxygen < MinSafeOxygen)
                return $"Oxygen Level: {CurrentOxygen:F1} mg/L (too low – increase aeration!)";

            return $"Oxygen Level: {CurrentOxygen:F1} mg/L (too high)";
        }

        public override string ToString()
        {
            return $"Oxygen Level: {CurrentOxygen:F1} mg/L";
        }
    }
}