using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaEngine
{
    public sealed class GameObject :BaseObject, IStartable, IUpdatable
    {
        private bool started;
        private List<Component> components;


        public GameObject(string name) //go must be have a name, it's his unique identifier
        {
            this.Name = name;
            components = new List<Component>();
        }


        public void Start()
        {
            //use this for initialization?
       
            started = true;
        }

        public void Update()
        {
            if (!started) Start();
        }

        /// <summary>
        /// Add a component object (or inherited) to a selected gameobject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return the instance of added component</returns>
        public T AddComponent<T>() where T : Component,new()
        {
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

        
    }
}
