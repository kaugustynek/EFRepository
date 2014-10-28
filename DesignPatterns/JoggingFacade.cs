using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IJoggingFacade
    {
        void StartJogging();
        void StopJogging();
    }

    public class JoggingFacade: IJoggingFacade
    {
        private readonly GPSController gps = new GPSController();
        private readonly MusicController music = new MusicController();
        private readonly WifiController wifi = new WifiController();
        private readonly SportsTrackerApp tracker = new SportsTrackerApp();


        public void StartJogging()
        {
            gps.IsSwitchedOn = true;
            music.IsSwitchedOn = true;
            wifi.IsSwitchedOn = true;
            tracker.Start();
        }

        public void StopJogging()
        {
            gps.IsSwitchedOn = false;
            music.IsSwitchedOn = false;
            wifi.IsSwitchedOn = false;
            tracker.Stop();
        }
    }
}
