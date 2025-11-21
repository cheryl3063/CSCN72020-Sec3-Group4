using System;

namespace SmartAquariumController
{
    /// <summary>
    /// Simple light control simulation for the Smart Aquarium Controller.
    /// Tracks whether the aquarium light is ON or OFF and provides methods to toggle it.
    /// </summary>
    public class LightControl
    {
        /// <summary>
        /// Current state of the aquarium light.
        /// </summary>
        public bool IsLightOn { get; private set; }

        public LightControl()
        {
            // Start with the light OFF by default
            IsLightOn = false;
        }

        /// <summary>
        /// Turn the aquarium light ON.
        /// </summary>
        public void TurnOn()
        {
            IsLightOn = true;
        }

        /// <summary>
        /// Turn the aquarium light OFF.
        /// </summary>
        public void TurnOff()
        {
            IsLightOn = false;
        }

        /// <summary>
        /// Toggle the aquarium light.
        /// </summary>
        public void Toggle()
        {
            IsLightOn = !IsLightOn;
        }

        /// <summary>
        /// Returns a user-friendly status string.
        /// </summary>
        public string GetStatus()
        {
            return IsLightOn ? "Light is ON" : "Light is OFF";
        }

        public override string ToString()
        {
            return GetStatus();
        }
    }
}