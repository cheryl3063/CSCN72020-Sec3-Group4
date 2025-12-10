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

            // Simulate feeder motor running
            await Task.Delay(3000);

            LastFedTime = DateTime.Now;
            IsFeeding = false;
        }

        // TEST EXPECTS "Idle" OR "Feeding"
        public string GetStatus()
        {
            return IsFeeding ? "Feeding" : "Idle";
        }
    }
}
