﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace AlphaEngine
{
    public abstract class Renderer:Component
    {
        public int width = 100;
        public int height = 100;

        protected Sprite sprite;

        protected Transform transform;

        public Renderer()
        {
            sprite = new Sprite(width, height);
        }


        /// <summary>
        /// Must be called in each inherited renderer update
        /// </summary>
        protected void UpdatePositions()
        {
            if (transform == null)
                transform = GameObject.GetComponent<Transform>();

            sprite.position = transform.Position;
        }
    }
}
