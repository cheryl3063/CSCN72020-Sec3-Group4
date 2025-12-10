using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartAquariumController;

namespace SmartAquariumController.Tests
{
    [TestClass]
    public class LightControlTests
    {
        [TestMethod]
        public void Toggle_ChangesState()
        {
            var light = new LightControl();
            bool before = light.IsLightOn;

            light.Toggle();

            Assert.AreNotEqual(before, light.IsLightOn);
        }
    }
}
