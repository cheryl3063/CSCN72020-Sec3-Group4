using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartAquariumController;

namespace SmartAquariumController.Tests
{
    [TestClass]
    public class FeederControlTests
    {
        [TestMethod]
        public void Status_ReturnsValidString()
        {
            var feeder = new FeederControl();
            string status = feeder.GetStatus();

            Assert.IsTrue(status == "Idle" || status == "Feeding");
        }
    }
}
