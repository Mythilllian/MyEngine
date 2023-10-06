using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class CameraComp : Comp
    {
        public CameraComp(TransformComp parent) : base(parent) { }

        public override void Awk() { }
        public override void Strt() { }
        public override void Upd(float dT) 
        {
            //parent.size = 
            //Todo:
            //Get screen size
        }
    }
}
