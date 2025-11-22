using System;
using System.IO;

namespace SmartAquariumController
{
    /// <summary>
    /// Simple fish feeder control simulation.
    /// Records each feeding time into "feeder_log.txt"
    /// and provides a method to trigger a feeding event.
    /// </summary>
    public class FeederControl
    {
        private readonly string _logFilePath;

        /// <summary>
        /// Last time feeding occurred.
        /// </summary>
        public DateTime LastFed { get; private set; }

        public FeederControl()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "feeder_log.txt");

            if (!File.Exists(_logFilePath))
            {
                File.WriteAllText(_logFilePath, "");
            }

            LastFed = DateTime.MinValue; // No feeding yet
        }

        /// <summary>
        /// Performs a feeding action and logs it.
        /// </summary>
        public void FeedFish()
        {
            LastFed = DateTime.Now;
            string entry = $"Fed at {LastFed:G}" + Environment.NewLine;

            File.AppendAllText(_logFilePath, entry);
        }

        /// <summary>
        /// Reads the entire feeding history from the log file.
        /// </summary>
        public string GetFeedingHistory()
        {
            try
            {
                return File.ReadAllText(_logFilePath);
            }
            catch
            {
                return "Unable to read feeding history.";
            }
        }

        public override string ToString()
        {
            return LastFed == DateTime.MinValue
                ? "Feeder: No feedings yet"
                : $"Feeder: Last fed at {LastFed:G}";
        }
    }
}