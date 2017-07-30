using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            scenesDirectoryPath = "../../"+scenesFolderPath;

            //ScenesName = Directory.GetDirectories(scenesDirectoryPath);
            //foreach (string s in ScenesName) //remove path from scene name
            //{
            //    s.Replace(scenesFolderPath, "");
            //}
        }
            

        /// <summary>
        /// Read the scene file from specific folder
        /// </summary>
        public static void LoadScene(string sceneName)
        {

        }
    }
}
