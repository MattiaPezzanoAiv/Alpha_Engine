using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace AlphaEngine
{
    public class Transform : Component
    {

        private List<Transform> children;
        private Transform parent;

        private Vector2 position;
        private Vector2 localPosition;


        public Transform()
        {
            children = new List<Transform>();
        }

        /// <summary>
        /// Set a new parent to this object, pass null argument for unparented object
        /// </summary>
        /// <param name="newParent"></param>
        public void SetParent(Transform newParent)
        {
            if (Parent == newParent) return; //setting the same parent

            if (Parent != null)
                Parent.children.Remove(this); //remove me from my father child

            if (newParent == null)
            {
                Parent = null;  //set my father null
            }
            else 
            {
                //parenting check
                Transform parentChecked = newParent;
                while(parentChecked != null)
                {
                    if (parentChecked.parent == this)
                        throw new RedundantFatherException();
                    else
                        parentChecked = parentChecked.Parent;
                }
                Parent = newParent;
                Parent.children.Add(this);
            }
        }
        public Transform Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        public int ChildCount
        {
            get
            {
                return children.Count;
            }
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public Vector2 LocalPosition
        {
            get;
            set;
        }
    }
}
