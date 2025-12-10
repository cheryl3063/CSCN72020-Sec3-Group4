using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace SmartAquariumController
{
    // Holds computed stats for a sensor
    public class SensorAnalytics
    {
        public double Average { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public int AlertCount { get; set; }
    }

    // Holds total alerts
    public class AlertSummary
    {
        public int TemperatureAlerts { get; set; }
        public int PHAlerts { get; set; }
        public int OxygenAlerts { get; set; }
    }

    public class AnalyticsEngine
    {
        private List<LogEntry> logs;

        // ------------------------
        // FIX #1 — PARAMETERLESS CONSTRUCTOR
        // ------------------------
        public AnalyticsEngine()
        {
            logs = new List<LogEntry>();
        }

        // Original constructor preserved
        public AnalyticsEngine(List<LogEntry> logs)
        {
            this.logs = logs ?? new List<LogEntry>();
        }

        // ------------------------
        // FIX #2 — LOAD JSON LOGS
        // ------------------------
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
                logs = new List<LogEntry>(); // fallback if corrupted
            }
        }

        // ------------------------
        // FIX #3 — MainDashboard calls this every tick
        // For now, Tonse does not need to implement logic here.
        // ------------------------
        public void LogNewEventIfNeeded()
        {
            // Placeholder — Sprint 3 requirement satisfied
        }

        // ---------------- TEMPERATURE ----------------
        public SensorAnalytics GetTemperatureAnalytics()
        {
            var readings = ExtractNumbers("Temperature:");
            return BuildAnalytics(readings, "Temperature");
        }

        // ---------------- pH ----------------
        public SensorAnalytics GetPHAnalytics()
        {
            var readings = ExtractNumbers("pH");
            return BuildAnalytics(readings, "pH");
        }

        // ---------------- OXYGEN ----------------
        public SensorAnalytics GetOxygenAnalytics()
        {
            var readings = ExtractNumbers("Oxygen");
            return BuildAnalytics(readings, "Oxygen");
        }

        // ---------------- ALL ALERTS SUMMARY ----------------
        public AlertSummary GetAlertSummary()
        {
            return new AlertSummary
            {
                TemperatureAlerts = CountAlerts("Temperature"),
                PHAlerts = CountAlerts("pH"),
                OxygenAlerts = CountAlerts("Oxygen")
            };
        }

        // ---------------- HELPERS ----------------
        private SensorAnalytics BuildAnalytics(List<double> readings, string alertKeyword)
        {
            return new SensorAnalytics
            {
                Average = readings.Any() ? readings.Average() : 0,
                Min = readings.Any() ? readings.Min() : 0,
                Max = readings.Any() ? readings.Max() : 0,
                AlertCount = CountAlerts(alertKeyword)
            };
        }

        private int CountAlerts(string keyword)
        {
            return logs.Count(l =>
                l.Message != null &&
                l.Message.ToLower().Contains(keyword.ToLower()));
        }

        private List<double> ExtractNumbers(string prefix)
        {
            var result = new List<double>();

            foreach (var log in logs)
            {
                if (log.Message == null || !log.Message.ToLower().Contains(prefix.ToLower()))
                    continue;

                // Example formats:
                // (29.0 °C)
                // (3.1 mg/L)
                // (9.23)
                int start = log.Message.IndexOf("(");
                int end = log.Message.IndexOf(")");

                if (start == -1 || end == -1) continue;

                string inside = log.Message.Substring(start + 1, end - start - 1);
                string numberText = inside.Split(' ')[0];

                if (double.TryParse(numberText, out double value))
                    result.Add(value);
            }

            return result;
        }
    }
}