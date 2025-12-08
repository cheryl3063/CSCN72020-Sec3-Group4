using System;
using System.Threading.Tasks;

namespace SmartAquariumController
{
    public class FeederControl
    {
        public bool IsFeeding { get; private set; }
        public DateTime LastFedTime { get; private set; }

        public async Task FeedNow()
        {
            if (IsFeeding)
                return;

            IsFeeding = true;

            // Simulate feeder motor running 3 seconds
            await Task.Delay(3000);

            LastFedTime = DateTime.Now;
            IsFeeding = false;
        }

        public string GetStatus()
        {
            return IsFeeding ? "Feeder: Feeding" : "Feeder: Idle";
        }
    }
}