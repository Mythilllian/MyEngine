using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameEngine
{
    public class RenderObject
    {
        public Bitmap sprite;
        public Vector2 position;
        public Vector2 size;
        public float rotation { 
            get { return rotation; } 
            set { rotation = (value % 360) + (int)(value / 360) + (value < 0 ? 360 : 0); } 
        }
    }
}
