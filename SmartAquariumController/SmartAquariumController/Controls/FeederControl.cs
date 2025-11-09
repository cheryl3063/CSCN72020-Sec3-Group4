using System;
using System.IO;

namespace SmartAquariumController.Controls
{
    public class FeederControl
    {
        public int LastDispenseGrams { get; private set; }

        public void Dispense(int grams)
        {
            LastDispenseGrams = grams;

            // Log each feed event to a file
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(basePath, "feeder_log.txt");
            File.AppendAllText(filePath, $"{DateTime.Now:HH:mm:ss} - Dispensed {grams}g\n");
        }

        public override string ToString()
        {
            return $"Last Feed: {LastDispenseGrams}g";
        }
    }
}