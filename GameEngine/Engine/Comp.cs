using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public abstract class Comp
    {
        public TransformComp parent { get; private set; }
        public bool active = true;

        public Comp()
        {
            ExpressedEngine.RegisterComp(this);
        }

        public Comp(TransformComp parent)
        {
            SetParent(parent);
            ExpressedEngine.RegisterComp(this);
        }

        /// <summary>
        /// Sets the parent of a Comp
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(TransformComp parent)
        {
            if(this.parent != default(TransformComp)) { parent.children.Remove(this); }
            this.parent = parent;
            parent.children.Add(this);
        }

        public abstract void OnParentChange();
        public abstract void OnStart();
        public abstract void OnUpdate(float dT);

        public void Destroy()
        {
            parent.children.Remove(this);
            ExpressedEngine.RemoveComp(this);
        }
    }
}
