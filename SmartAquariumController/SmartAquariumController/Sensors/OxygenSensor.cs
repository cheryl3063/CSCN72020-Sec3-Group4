using System;
using System.IO;

namespace SmartAquariumController.Sensors
{
    public class OxygenSensor
    {
        public double Value { get; private set; }
        public string Unit => "mg/L";

        public void Update()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "oxygen.txt");

                // Create a default file if missing
                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, "6.5");

                string text = File.ReadAllText(filePath).Trim();

                if (double.TryParse(text, out double o2))
                    Value = o2;
                else
                    Value = 0;
            }
            catch
            {
                Value = 0; // fallback value
            }
        }

        public override string ToString()
        {
            return $"O₂ Level: {Value} {Unit}";
        }
    }
}