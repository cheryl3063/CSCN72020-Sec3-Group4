using System;
using System.IO;

namespace SmartAquariumController.Sensors
{
    public class TemperatureSensor
    {
        public double Value { get; private set; }
        public string Unit => "°C";

        // Read temperature from file or return 0 if missing
        public void Update()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "temperature.txt");

                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "25"); // create file if missing
                }

                string text = File.ReadAllText(filePath).Trim();

                if (double.TryParse(text, out double temp))
                    Value = temp;
                else
                    Value = 0; // fallback if invalid content
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading temperature: " + ex.Message);
            }
        }
    }
}
