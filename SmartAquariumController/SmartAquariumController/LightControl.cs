using System;

namespace SmartAquariumController
{
    /// <summary>
    /// Sprint 2: Upgraded LightControl with:
    /// - Auto day/night cycle simulation
    /// - Manual override
    /// - State-change detection
    /// - Clean status reporting
    /// </summary>
    public class LightControl
    {
        public bool IsLightOn { get; private set; }
        public bool ManualOverride { get; private set; }

        private bool lastState = false;         // Used to detect changes for logging
        private int simulatedHour = 0;          // 0–23 simulated time

        public LightControl()
        {
            IsLightOn = false;
            ManualOverride = false;
        }

        /// <summary>
        /// Toggles light manually (manual override mode)
        /// </summary>
        public void Toggle()
        {
            ManualOverride = true;
            IsLightOn = !IsLightOn;
        }

        /// <summary>
        /// Turns light ON manually
        /// </summary>
        public void TurnOn()
        {
            ManualOverride = true;
            IsLightOn = true;
        }

        /// <summary>
        /// Turns light OFF manually
        /// </summary>
        public void TurnOff()
        {
            ManualOverride = true;
            IsLightOn = false;
        }

        /// <summary>
        /// Automatic day/night cycle:
        /// - Daytime (06:00–20:00): Light ON
        /// - Nighttime (20:00–06:00): Light OFF
        /// </summary>
        public void UpdateAutoCycle()
        {
            if (ManualOverride)
                return;   // Skip auto rules if user toggled manually

            // Advance simulated hour
            simulatedHour = (simulatedHour + 1) % 24;

            bool shouldBeOn = simulatedHour >= 6 && simulatedHour < 20;

            IsLightOn = shouldBeOn;
        }

        public void ResetToAuto()
        {
            ManualOverride = false;
        }

        /// <summary>
        /// Returns TRUE only when the light actually changes (used for logging)
        /// </summary>
        public bool CheckForStateChange()
        {
            if (IsLightOn != lastState)
            {
                lastState = IsLightOn;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns readable status for UI
        /// </summary>
        public string GetStatus()
        {
            if (ManualOverride)
                return IsLightOn ? "Light: ON (Manual)" : "Light: OFF (Manual)";
            else
                return IsLightOn ? "Light: ON (Auto)" : "Light: OFF (Auto)";
        }
    }
}