using System;
using System.Globalization;
using System.IO;

namespace SmartAquariumController.Sensors
{
    public class PHSensor
    {
        public double Value { get; private set; }

        public void Update()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "ph.txt");

                // Create with a sane default if missing
                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, "7.2");

                // Read and parse using invariant culture (so 7.2 works everywhere)
                string text = File.ReadAllText(filePath).Trim();
                Value = double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double ph)
                    ? ph
                    : 0.0;
            }
            catch
            {
                Value = 0.0; // never crash UI; safe fallback
            }
        }

        public override string ToString() => $"pH Level: {Value}";
    }
}