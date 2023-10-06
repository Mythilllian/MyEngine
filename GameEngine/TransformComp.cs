using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class TransformComp : Comp
    {
        public Comp[] children;

        public Vector2 position;
        public Vector2 size;
        public float rotation
        {
            get { return rotation; }
            set { rotation = (value % 360) + (int)(value / 360) + (value < 0 ? 360 : 0); }
        }

        public TransformComp(TransformComp parent, Vector2 position, Vector2 size, float rotation = 0f) : base(parent)
        {
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }

        public override void Awk() { }
        public override void Strt() { }
        public override void Upd(float dT) { }
    }
}
