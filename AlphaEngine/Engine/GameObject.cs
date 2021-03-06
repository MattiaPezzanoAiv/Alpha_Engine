﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AlphaEngine
{
    public sealed class GameObject : BaseObject, IStartable, IUpdatable
    {
        private bool started;
        private List<Component> components;


        public GameObject(string name) //go must be have a name, it's his unique identifier
        {
            this.Name = name;
            components = new List<Component>();
        }

        /// <summary>
        /// Return a number of attached components
        /// </summary>
        public int ComponentsCount
        {
            get
            {
                return components.Count;
            }
        }


        public void Start()
        {
            //use this for initialization?

            started = true;
        }

        public void Update()
        {
            if (!IsActive) return; //this go not activated


            if (!started) Start();

            foreach (Component c in components)
            {
                if (!c.IsActive) continue;
                if (!c.Started)
                {
                    c.Start();
                    c.SetStarted();
                }
                c.Update();
            }
        }

        /// <summary>
        /// Return the current attached transform, null if there is no transform attached
        /// </summary>
        public Transform Transform
        {
            get
            {
                return GetComponent<Transform>();
            }
        }

        /// <summary>
        /// Add a component object (or inherited) to a selected gameobject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return the instance of added component</returns>
        public T AddComponent<T>() where T : Component, new()
        {
            if(typeof(T) == typeof(Transform))
                if (GetComponent<Transform>() != null) //there is a transform attached
                    throw new MultipleTransformException();
            if (typeof(T).IsSubclassOf(typeof(Renderer)))
                if (GetComponent<Transform>() == null) //add a transform if there isnt
                    AddComponent<Transform>();

            T newComp = new T();
            newComp.SetOwner(this);
            components.Add(newComp);
            return newComp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return the first component of type T if is present, else return null</returns>
        public T GetComponent<T>() where T : Component
        {
            foreach (Component c in components)
            {
                if (c is T)
                    return (T)c;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return an array of all components of type T. An empty array if there are no components of type T</returns>
        public T[] GetComponents<T>() where T : Component
        {
            List<T> neededComponents = new List<T>();
            foreach (Component c in components)
            {
                if (c is T)
                    neededComponents.Add((T)c);
            }
            return neededComponents.ToArray();
        }

        /// <summary>
        /// Remove the first component of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return true if component was removed, else return false</returns>
        public bool RemoveComponent<T>() where T : Component
        {
            T toRemove = null;
            foreach (Component c in components)
            {
                if (c is T)
                {
                    toRemove = (T)c;
                    break;
                }
            }
            if (toRemove == null)
                return false;

            components.Remove(toRemove);
            return true;
        }








        //static props
        /// <summary>
        /// Create an instance of a gameobject in a current loaded scene
        /// </summary>
        public static void Instatiate(GameObject go)
        {
            //add go to the scene objects
        }

        public static GameObject ParseGOFromFile(string filepath)
        {
            if (AlphaEngine.ComponentsTypeMapping == null) throw new Exception("qui errore");

            GameObject currentGO = new GameObject(filepath);

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line = null;
                bool goRegion = true; //if true setting go parameters
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "") //is a separator, next component
                    {
                        goRegion = false;
                        continue;
                    }
                    if (line.StartsWith("#")) //is a comment line
                        continue;

                    if(goRegion && line.Contains(":")) //check go variable, not component
                    {
                        string[] lineSplitted = line.Split(':');
                        string value = lineSplitted[1];

                        PropertyInfo fieldInfo = currentGO.GetType().GetProperty(lineSplitted[0],BindingFlags.Public | BindingFlags.Instance);
                        if (fieldInfo == null)
                            throw new NotExistingFieldException();
                        if (fieldInfo.PropertyType == typeof(string))
                            fieldInfo.SetValue(currentGO, value);
                        else if (fieldInfo.PropertyType == typeof(float))
                            fieldInfo.SetValue(currentGO, float.Parse(value));
                        else if (fieldInfo.PropertyType == typeof(int))
                            fieldInfo.SetValue(currentGO, int.Parse(value));
                        else if (fieldInfo.PropertyType == typeof(bool))
                            fieldInfo.SetValue(currentGO, bool.Parse(value));
                    }

                    if (!line.Contains(":"))
                    {
                        //is a component name
                        if (!AlphaEngine.ComponentsTypeMapping.ContainsKey(line))
                            throw new NotAComponentException();
                        goRegion = false;
                        Type componentType = AlphaEngine.ComponentsTypeMapping[line];

                        MethodInfo addComponent = typeof(GameObject).GetMethod("AddComponent");
                        MethodInfo generic = addComponent.MakeGenericMethod(componentType);
                        generic.Invoke(currentGO, new object[] { });
                    }
                    else
                    {
                        //is a public field 
                    }
                }
            }
            return currentGO;
        }
    }
}
