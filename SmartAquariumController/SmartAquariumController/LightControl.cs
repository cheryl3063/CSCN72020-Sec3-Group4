using System;

namespace SmartAquariumController
{
    public class LightControl
    {
        public bool IsLightOn { get; private set; }
        public bool ManualOverride { get; private set; }

        private bool lastState = false;
        private int simulatedHour = 0;

        public LightControl()
        {
            IsLightOn = false;
            ManualOverride = false;
        }

        // Used by the test – just needs to flip IsLightOn
        public void Toggle()
        {
            ManualOverride = true;
            IsLightOn = !IsLightOn;
        }

        public void TurnOn()
        {
            ManualOverride = true;
            IsLightOn = true;
        }

        public void TurnOff()
        {
            ManualOverride = true;
            IsLightOn = false;
        }

        public void UpdateAutoCycle()
        {
            if (ManualOverride)
                return;

            simulatedHour = (simulatedHour + 1) % 24;
            bool shouldBeOn = simulatedHour >= 6 && simulatedHour < 20;
            IsLightOn = shouldBeOn;
        }

        public void ResetToAuto()
        {
            ManualOverride = false;
        }

        public bool CheckForStateChange()
        {
            if (IsLightOn != lastState)
            {
                lastState = IsLightOn;
                return true;
            }

            return false;
        }

        public string GetStatus()
        {
            if (ManualOverride)
                return IsLightOn ? "Light: ON (Manual)" : "Light: OFF (Manual)";
            else
                return IsLightOn ? "Light: ON (Auto)" : "Light: OFF (Auto)";
        }
    }
}
