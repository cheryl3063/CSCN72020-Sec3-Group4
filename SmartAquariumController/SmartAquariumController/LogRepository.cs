using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SmartAquariumController
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        // Needed for JSON deserialization
        public LogEntry() { }

        // Used by tests & logging
        public LogEntry(string message)
        {
            Timestamp = DateTime.Now;
            Message = message;
        }
    }

    public class LogRepository
    {
        private readonly string logFilePath = "log.json";

        public List<LogEntry> Logs { get; private set; }

        public LogRepository()
        {
            if (File.Exists(logFilePath))
            {
                try
                {
                    string json = File.ReadAllText(logFilePath);
                    Logs = JsonSerializer.Deserialize<List<LogEntry>>(json)
                           ?? new List<LogEntry>();
                }
                catch
                {
                    Logs = new List<LogEntry>();
                }
            }
            else
            {
                Logs = new List<LogEntry>();
                SaveLogs(); // create empty log.json
            }
        }

        public void AddLog(string message)
        {
            Logs.Add(new LogEntry(message));
            SaveLogs();
        }

        private void SaveLogs()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(Logs, options);
            File.WriteAllText(logFilePath, json);
        }
    }
}
