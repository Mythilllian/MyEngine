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

        public CameraComp() : base() {  }
        public CameraComp(Color backgroundColor) : base() { this.backgroundColor = backgroundColor; }

        public override void OnParentChange() { }
        public override void OnStart() { }
        public override void OnUpdate(float dT) { }

    }
}
