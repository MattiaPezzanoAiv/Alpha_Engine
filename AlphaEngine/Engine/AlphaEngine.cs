using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace AlphaEngine
{
    public static class AlphaEngine
    {
        private static Window window;
        private static Time time;

        public static void Init(string contextName, Vector2 contextSize, bool fullScreen = false, int depthSize = 16, int antialiasingSamples = 0, int stencilBuffers = 0)
        {
            window = new Window((int)contextSize.X, (int)contextSize.Y, contextName, fullScreen, depthSize, antialiasingSamples, stencilBuffers);
            time = new Time(window);

        }


        public static void Run()
        {

            while(true)
            {

                window.Update();
            }
        }

        public static Time Time
        {
            get
            {
                return time;
            }
        }

        /// <summary>
        /// Update Engine for only one tick
        /// </summary>
        public static void Tick()
        {
            window.Update();
        }
    }
}
