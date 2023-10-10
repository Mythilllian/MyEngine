using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public struct TransformStruct
    {
        public Vector2 position;
        public Vector2 size;
        public float rotation;

        public TransformStruct(Vector2 position, Vector2 size, float rotation) 
        { 
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }

        public TransformStruct(TransformComp comp) 
        {
            position = comp.position;
            size = comp.size;
            rotation = comp.rotation;
        }
    }
}
