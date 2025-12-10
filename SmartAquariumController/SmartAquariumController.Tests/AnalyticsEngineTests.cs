using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartAquariumController;
using System.Collections.Generic;

namespace SmartAquariumController.Tests
{
    [TestClass]
    public class AnalyticsEngineTests
    {
        [TestMethod]
        public void TemperatureAnalytics_WorksCorrectly()
        {
            var logs = new List<LogEntry>
            {
                new LogEntry("Temperature High (30.0 °C)"),
                new LogEntry("Temperature Back to Normal (25.0 °C)"),
                new LogEntry("Temperature Low (18.0 °C)")
            };

            var engine = new AnalyticsEngine(logs);
            var stats = engine.GetTemperatureAnalytics();

            Assert.AreEqual(3, stats.AlertCount);
            Assert.AreEqual(18.0, stats.Min);
            Assert.AreEqual(30.0, stats.Max);
        }

        [TestMethod]
        public void PHAnalytics_WorksCorrectly()
        {
            var logs = new List<LogEntry>
            {
                new LogEntry("pH Out of Range (9.1)"),
                new LogEntry("pH Back to Normal (7.4)")
            };

            var engine = new AnalyticsEngine(logs);
            var stats = engine.GetPHAnalytics();

            Assert.AreEqual(2, stats.AlertCount);
            Assert.AreEqual(9.1, stats.Max);
        }

        [TestMethod]
        public void OxygenAnalytics_WorksCorrectly()
        {
            var logs = new List<LogEntry>
            {
                new LogEntry("Oxygen Low (3.4 mg/L)"),
                new LogEntry("Oxygen Back to Normal (6.0 mg/L)")
            };

            var engine = new AnalyticsEngine(logs);
            var stats = engine.GetOxygenAnalytics();

            Assert.AreEqual(2, stats.AlertCount);
            Assert.AreEqual(3.4, stats.Min);
        }
    }
}
