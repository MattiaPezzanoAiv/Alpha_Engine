using System;
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
            GameObject go = new GameObject("pippo");
            GameObject go2 = GameObject.ParseGOFromFile("../../TestFolder/MyFirstGameObject.txt");


            Console.ReadLine();
        }
    }
}
