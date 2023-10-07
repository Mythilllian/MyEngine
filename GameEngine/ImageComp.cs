using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ImageComp : Comp
    {
        public Bitmap img;

        public ImageComp(TransformComp? parent) : base(parent) { }

        public override void Awk() { }
        public override void Strt() { }
        public override void Upd(float dT) { }
    }
}
