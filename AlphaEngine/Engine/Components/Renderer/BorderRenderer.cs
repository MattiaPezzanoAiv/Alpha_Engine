using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace AlphaEngine
{
    public sealed class BorderRenderer:Renderer
    {
        public Color BorderColor { get; private set; }
        

        public BorderRenderer():base()
        {
            BorderColor = new Color(new Vector4(1, 1, 1, 1));
        }

        public override void Update()
        {
            UpdatePosition();
            
            sprite.DrawColor(BorderColor.ToVector4());
        }


        public void SetColor(Color color)
        {
            BorderColor = color;
        }
    }
}
