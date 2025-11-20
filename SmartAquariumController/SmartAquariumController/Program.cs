using System;
using System.IO;
using System.Windows.Forms;

namespace SmartAquariumController
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Prepare simulation files before launching the app
            InitializeSensorFiles();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainDashboard());
        }

        /// <summary>
        /// Ensures that all sensor simulation files exist with default values.
        /// This prevents crashes on machines that don't have the files yet.
        /// </summary>
        private static void InitializeSensorFiles()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Sensor simulation files
            string tempFile = Path.Combine(baseDir, "temperature.txt");
            string phFile = Path.Combine(baseDir, "ph.txt");
            string oxygenFile = Path.Combine(baseDir, "oxygen.txt");
            string feederLogFile = Path.Combine(baseDir, "feeder_log.txt");

            // Only sensors need files → LightControl does NOT
            if (!File.Exists(tempFile))
                File.WriteAllText(tempFile, "25");  // Default 25°C

            if (!File.Exists(phFile))
                File.WriteAllText(phFile, "7.2");  // Default pH

            if (!File.Exists(oxygenFile))
                File.WriteAllText(oxygenFile, "6.5"); // Default mg/L

            if (!File.Exists(feederLogFile))
                File.WriteAllText(feederLogFile, ""); // Empty log file
        }
    }
}
