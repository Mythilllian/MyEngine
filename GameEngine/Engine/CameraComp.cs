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

        public CameraComp() : base() { }
        public CameraComp(Color backgroundColor) : base() { this.backgroundColor = backgroundColor; }

        public override void OnStart() { }
        public override void OnUpdate(float dT) 
        {
            parent.size = new Vector2(ExpressedEngine.Window.Size.Width, ExpressedEngine.Window.Size.Height);
        }

    }
}
