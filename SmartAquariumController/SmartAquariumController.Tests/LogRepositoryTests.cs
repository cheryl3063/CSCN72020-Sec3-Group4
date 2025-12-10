using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartAquariumController;
using System.IO;

namespace SmartAquariumController.Tests
{
    [TestClass]
    public class LogRepositoryTests
    {
        [TestMethod]
        public void AddLog_CreatesJsonFile()
        {
            // delete old log file to ensure clean test
            if (File.Exists("log.json"))
                File.Delete("log.json");

            var repo = new LogRepository();

            repo.AddLog("Test event");

            Assert.IsTrue(File.Exists("log.json"));

            string content = File.ReadAllText("log.json");
            Assert.IsTrue(content.Contains("Test event"));
        }
    }
}
