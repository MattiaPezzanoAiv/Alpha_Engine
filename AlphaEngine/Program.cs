﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace AlphaEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            AlphaEngine.Init("test", new Vector2(50, 50));
            AlphaEngine.Run();
        }
    }
}
