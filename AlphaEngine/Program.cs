using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using System.IO;

namespace AlphaEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            AlphaEngine.Init("", new Vector2(50,50));
            GameObject go = new GameObject("pippo");
            GameObject go2 = GameObject.ParseGOFromFile("../../../AlphaEngine.Test/TestFolder/NotAComponent.txt");


            Console.ReadLine();
        }
    }
}
