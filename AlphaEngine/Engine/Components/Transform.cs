using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace AlphaEngine
{
    public sealed class Transform : Component
    {

        private List<Transform> children;
        private Transform parent;

        private Vector2 position;
        private Vector2 localPosition;

        private Vector2 localScale;


        public Transform()
        {
            children = new List<Transform>();
            localScale = new Vector2(1, 1);
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
                while (parentChecked != null)
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
        #region _GLOBAL
        public Vector2 Position
        {
            get
            {
                if (Parent != null)
                    return Parent.position + localPosition;
                return position;
            }
            set
            {
                position = value;
                if (Parent != null)
                    localPosition = position - Parent.Position;
                else
                    localPosition = value;
            }
        }
        public Vector2 Scale
        {
            get // like position but when get world scale return the product of all parents 
            {
                Vector2 scale = localScale;
                Transform _parent = parent;
                while(_parent != null)
                {
                    float x = scale.X * _parent.LocalScale.X;
                    float y = scale.Y * _parent.LocalScale.Y;
                    scale = new Vector2(x, y);
                    _parent = _parent.Parent; //get parent of current parent
                }
                return scale;
            }
          
        }
        #endregion


        #region _LOCAL
        public Vector2 LocalPosition
        {
            get
            {
                return localPosition;
            }
            set
            {
                localPosition = value;

                if (Parent == null)
                {
                    Position = value;
                }
                else
                {
                    Position = Parent.Position + localPosition;
                }
            }
        }
        public Vector2 LocalScale   //NO COMPLETE
        {
            get
            {
                return localScale;
            }
            set
            {
                localScale = value;
            }
        }
        #endregion
    }
}
