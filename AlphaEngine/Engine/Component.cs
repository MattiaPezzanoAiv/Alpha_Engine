using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaEngine
{
    public abstract class Component : IStartable, IUpdatable, IAwakable
    {

        private GameObject gameObject;

        /// <summary>
        /// Represent gameobject to which this component is attached
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }
        }

        public bool IsActive { get; set; } = true;

       

        public virtual void Awake()
        {

        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }


        /// <summary>
        /// WARNING: this method is internally used, if you try to use this,
        /// simply the action will be ignored.
        /// </summary>
        public void SetOwner(GameObject owner)
        {
            if (gameObject != null) return; //check for future use

            gameObject = owner;
        }
    }
}
