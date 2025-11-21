using System;
using System.IO;

namespace SmartAquariumController
{
    /// <summary>
    /// Simple pH sensor simulation for the Smart Aquarium Controller.
    /// Reads a value from "ph.txt" and provides range checking.
    /// </summary>
    public class PHSensor
    {
        private readonly string _filePath;

        /// <summary>
        /// Last pH value read.
        /// </summary>
        public double CurrentPH { get; private set; }

        /// <summary>
        /// Safe range (typical freshwater fish).
        /// </summary>
        public double MinSafePH { get; } = 6.5;
        public double MaxSafePH { get; } = 7.5;

        public PHSensor()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ph.txt");

            // Create default pH file if missing
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "7.2");
            }

            Update();
        }

        /// <summary>
        /// Reads the latest pH value from the file.
        /// </summary>
        public void Update()
        {
            try
            {
                string text = File.ReadAllText(_filePath).Trim();

                if (double.TryParse(text, out double value))
                {
                    CurrentPH = value;
                }
                else
                {
                    CurrentPH = 7.2;
                }
            }
            catch
            {
                CurrentPH = 7.2;
            }
        }

        /// <summary>
        /// Returns true if pH is in safe range.
        /// </summary>
        public bool IsInSafeRange()
        {
            return CurrentPH >= MinSafePH && CurrentPH <= MaxSafePH;
        }

        /// <summary>
        /// Friendly status message.
        /// </summary>
        public string GetStatus()
        {
            if (IsInSafeRange())
                return $"pH Level: {CurrentPH:F1} (safe)";

            if (CurrentPH < MinSafePH)
                return $"pH Level: {CurrentPH:F1} (too acidic — add buffer)";

            return $"pH Level: {CurrentPH:F1} (too alkaline — adjust water)";
        }

        public override string ToString()
        {
            return $"pH Level: {CurrentPH:F1}";
        }
    }
}