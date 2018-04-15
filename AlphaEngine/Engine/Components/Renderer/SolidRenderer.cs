using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace AlphaEngine
{
    public sealed class SolidRenderer:Renderer
    {

        public Color SolidColor { get; private set; }
        

        public SolidRenderer():base()
        {
            SolidColor = new Color(new Vector4(1,1,1,1));
        }

        public override void Update()
        {
            base.Update();
            sprite.DrawSolidColor(SolidColor.ToVector4());
        }


        public void SetColor(Color color)
        {
            SolidColor = color;
        }
        

    }
}
