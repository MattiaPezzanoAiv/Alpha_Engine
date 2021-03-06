﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using System.Reflection;


namespace AlphaEngine
{
    public static class AlphaEngine
    {
        private static Window window;
        private static Time time;
        private static Dictionary<string, Type> componentsTypeMapping;

        public static void Init(string contextName, Vector2 contextSize,string scenesPath, bool fullScreen = false, int depthSize = 16, int antialiasingSamples = 0, int stencilBuffers = 0)
        {
            window = new Window((int)contextSize.X, (int)contextSize.Y, contextName, fullScreen, depthSize, antialiasingSamples, stencilBuffers);
            time = new Time(window);
            SceneManager.Init(scenesPath);

            
            #region DEVELOPMENT_IN_PAUSE
            
            //paused this code development fo a test problem on assembly(code is ok but test fail)

            //initialization of type dictionary
            componentsTypeMapping = new Dictionary<string, Type>();

            //Assembly executingAssembly = Assembly.GetEntryAssembly(); //is ok
            Assembly executingAssembly = Assembly.GetAssembly(typeof(AlphaEngine));
            Console.WriteLine(executingAssembly);

            if (executingAssembly != null)
            {
                foreach (Type t in executingAssembly.GetTypes())
                {
                    if (t.IsSubclassOf(typeof(Component)))
                    {
                        componentsTypeMapping[t.Name] = t;
                    }
                }
            }
            
            AssemblyName[] assemblyNames = executingAssembly.GetReferencedAssemblies();
            if (assemblyNames == null) Console.WriteLine("is null");
            foreach (AssemblyName assemblyName in assemblyNames)
            {
                Assembly refAssembly = Assembly.GetAssembly(assemblyName.GetType());
                Type[] assemblyTypes = refAssembly.GetTypes();
                foreach (Type t in assemblyTypes)
                {
                    if (t.IsSubclassOf(typeof(Component)))
                    {
                        componentsTypeMapping[t.Name] = t;
                    }
                }
            }
            
            #endregion
            
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

        public static Dictionary<string,Type> ComponentsTypeMapping
        {
            get
            {
                return componentsTypeMapping;
            }
        }
    }
}
