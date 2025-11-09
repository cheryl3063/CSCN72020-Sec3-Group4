using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAquariumController.Controls
{
    public class LightControl
    {
        public bool IsOn { get; private set; }

        public void Toggle()
        {
            // Switches the light state each time the method is called
            IsOn = !IsOn;
        }

        public override string ToString()
        {
            // Returns a readable message showing light status
            return IsOn ? "Light: ON" : "Light: OFF";
        }
    }
}
