using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SmartAquariumController
{
    public class SensorAnalytics
    {
        public double Average { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public int AlertCount { get; set; }
    }

    public class AlertSummary
    {
        public int TemperatureAlerts { get; set; }
        public int PHAlerts { get; set; }
        public int OxygenAlerts { get; set; }
    }

    public class AnalyticsEngine
    {
        private List<LogEntry> logs;

        public AnalyticsEngine()
        {
            logs = new List<LogEntry>();
        }

        public AnalyticsEngine(List<LogEntry> logs)
        {
            this.logs = logs ?? new List<LogEntry>();
        }

        public void LoadLogs()
        {
            if (!File.Exists("log.json"))
            {
                logs = new List<LogEntry>();
                return;
            }

            try
            {
                string json = File.ReadAllText("log.json");
                logs = JsonSerializer.Deserialize<List<LogEntry>>(json) ?? new List<LogEntry>();
            }
            catch
            {
                logs = new List<LogEntry>();
            }
        }

        // REQUIRED because MainDashboard calls it
        public void LogNewEventIfNeeded()
        {
            // left empty intentionally
        }

        public SensorAnalytics GetTemperatureAnalytics()
        {
            var readings = ExtractNumbers(log =>
                log.Message != null &&
                log.Message.ToLower().Contains("temperature"));

            return BuildAnalytics(readings);
        }

        public SensorAnalytics GetPHAnalytics()
        {
            var readings = ExtractNumbers(log =>
                log.Message != null &&
                log.Message.ToLower().Contains("pH".ToLower()));

            return BuildAnalytics(readings);
        }

        public SensorAnalytics GetOxygenAnalytics()
        {
            var readings = ExtractNumbers(log =>
                log.Message != null &&
                log.Message.ToLower().Contains("oxygen"));

            return BuildAnalytics(readings);
        }

        public AlertSummary GetAlertSummary()
        {
            return new AlertSummary
            {
                TemperatureAlerts = CountAlerts("temperature"),
                PHAlerts = CountAlerts("pH"),
                OxygenAlerts = CountAlerts("oxygen")
            };
        }

        private int CountAlerts(string keyword)
        {
            keyword = keyword.ToLower();

            return logs.Count(l =>
                l.Message != null &&
                l.Message.ToLower().Contains(keyword));
        }

        private List<double> ExtractNumbers(Func<LogEntry, bool> filter)
        {
            var results = new List<double>();

            foreach (var log in logs.Where(filter))
            {
                if (log.Message == null) continue;

                int start = log.Message.IndexOf('(');
                int end = log.Message.IndexOf(')');

                if (start == -1 || end == -1 || end <= start + 1)
                    continue;

                string inside = log.Message.Substring(start + 1, end - start - 1);

                // FIX: Split must use char[] not single char with StringSplitOptions
                string[] parts = inside.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                string numberText = parts[0];

                if (double.TryParse(numberText, out double value))
                    results.Add(value);
            }

            return results;
        }

        private SensorAnalytics BuildAnalytics(List<double> readings)
        {
            if (readings == null || readings.Count == 0)
            {
                return new SensorAnalytics
                {
                    Average = 0,
                    Min = 0,
                    Max = 0,
                    AlertCount = 0
                };
            }

            return new SensorAnalytics
            {
                Average = readings.Average(),
                Min = readings.Min(),
                Max = readings.Max(),
                AlertCount = readings.Count
            };
        }
    }
}
