using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class ImageComp : Comp
    {
        public Image img = null;

        public ImageComp() : base() { }
        public ImageComp(Image img) : base() { this.img = img; }


        public override void OnParentChange() { }
        public override void OnStart() { }
        public override void OnUpdate(float dT) { }
    }
}
