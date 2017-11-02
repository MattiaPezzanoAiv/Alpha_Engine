using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Aiv.Fast2D;

namespace AlphaEngine
{
    public static class SceneManager
    {

        //private static string[] ScenesName;
        private static string scenesDirectoryPath;


        /// <summary>
        /// Current scene objects, the string key is the gameobjects name
        /// </summary>
        private static Dictionary<string, GameObject> loadedObjects;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenesFolderPath">The path of directory where are situated all scenes</param>
        public static void Init(string scenesFolderPath)
        {
            scenesDirectoryPath = "../../" + scenesFolderPath;
            
        }
        
        public static void TickGameObjects()  //do test
        {
            if (loadedObjects == null || loadedObjects.Count <= 0)
                return;
            foreach (var go in loadedObjects)
            {
                go.Value.Update();
            }
        }


        /// <summary>
        /// Return the gameobject with the selected name if it was loaded, else return null
        /// </summary>
        /// <param name="name"></param>
        public static GameObject GetObject(string name)  //do test
        {
            if (loadedObjects.ContainsKey(name))
                return loadedObjects[name];
            return null;
        }

        /// <summary>
        /// Read the scene file from specific folder
        /// </summary>
        /// <param name="sceneName">The name of the file in a scene folder (excludin gpath)</param>
        public static void LoadScene(string sceneName)  //do test
        {
            string fullScenePath = scenesDirectoryPath + sceneName;
            string[] sceneGO = Directory.GetFiles(fullScenePath);

            //instance new scene
            loadedObjects = new Dictionary<string, GameObject>();
            foreach (var go in sceneGO)
            {
                GameObject myGo = GameObject.ParseGOFromFile(go);
                if (loadedObjects.ContainsKey(myGo.Name))
                    throw new AlredyLoadedObjectException();  //do test
                loadedObjects.Add(myGo.Name, myGo);
            }
        }
    }
}
