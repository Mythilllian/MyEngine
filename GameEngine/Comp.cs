using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class Comp
    {
        public TransformComp parent { get; private set; }
        public bool active = true;

        public Comp(TransformComp? parent)
        {
            this.parent = parent;
            ExpressedEngine.RegisterComp(this);
        }

        public abstract void Awk();
        public abstract void Strt();
        public abstract void Upd(float dT);
    }
}
