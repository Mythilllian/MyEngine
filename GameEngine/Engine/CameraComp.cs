using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class CameraComp : Comp
    {
        public Color backgroundColor = Color.Blue;

        public CameraComp(TransformComp? parent) : base(parent) { }
        public CameraComp(TransformComp? parent, Color backgroundColor) : base(parent) { this.backgroundColor = backgroundColor; }

        public override void Strt() { }
        public override void Upd(float dT) 
        {
            parent.size = new Vector2(ExpressedEngine.Window.Size.Width, ExpressedEngine.Window.Size.Height);
        }

    }
}
