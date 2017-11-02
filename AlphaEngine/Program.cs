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
            AlphaEngine.Init("", new Vector2(10, 10), "");
            Window w = new Window(500, 500, "");
            GameObject go2 = GameObject.ParseGOFromFile("../../TestFolder/MyFirstGameObject.txt");
            Console.WriteLine(go2.IsActive);
            Console.ReadLine();
            GameObject pippo = new GameObject("pippo");
            SolidRenderer r = pippo.AddComponent<SolidRenderer>();
            r.SetColor(Color.Red);
            pippo.Transform.Position = new Vector2(10, 10);
            pippo.Transform.LocalScale = new Vector2(3, 3);
            
            while(w.opened)
            {

                pippo.Update();
                w.Update();
            }
            return;
            GameObject go1 = new GameObject("");
            Transform t1 = go1.AddComponent<Transform>();

            //GameObject go2 = new GameObject("a");
            Transform t2 = go2.AddComponent<Transform>();
            //AlphaEngine.Init("", new Vector2(50,50));
            //GameObject go = new GameObject("pippo");

            t1.SetParent(t2);
            t2.Position = new Vector2(10, 10);

            t1.LocalPosition = new Vector2(10, 10);

            t2.Position += new Vector2(50, 50);

            Console.WriteLine(t1.Position);

            Console.ReadLine();
        }
    }
}
