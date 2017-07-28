using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace AlphaEngine
{
    public class Time
    {
        private Window window;
        private float timeScale;


        public Time(Window window)
        {
            this.window = window;
            timeScale = 1;
        }
        


        public float DeltaTime
        {
            get
            {
                return window.deltaTime * timeScale;
            }
        }
        public float UnscaledDeltaTime
        {
            get
            {
                return window.deltaTime;
            }
        }
        public float TimeScale
        {
            get
            {
                return timeScale;
            }
            set
            {
                timeScale = value;
            }
        }
    }
}
