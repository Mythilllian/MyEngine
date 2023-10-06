using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class Comp
    {
        public TransformComp parent { get; set; }
        public bool active = true;

        public Comp(TransformComp parent)
        {
            this.parent = parent;
        }

        public abstract void Awk();
        public abstract void Strt();
        public abstract void Upd(float dT);
    }
}
