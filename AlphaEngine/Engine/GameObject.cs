using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaEngine
{
    public class GameObject :BaseObject, IStartable, IUpdatable
    {
        private bool started;

        public GameObject(string name) //go must be have a name, it's his unique identifier
        {
            this.Name = name;

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
    }
}
