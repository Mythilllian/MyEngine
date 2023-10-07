using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class TransformComp : Comp
    {
        public string name = "DefaultName";
        public string tag = "DefaultTag";
        
        public Comp[] children;

        public Vector2 position;
        public Vector2 size;
        public float rotation
        {
            get { return rotation; }
            set { rotation = (value % 360) + (int)(value / 360) + (value < 0 ? 360 : 0); }
        }

        public TransformComp(TransformComp? parent, Vector2 position, Vector2 size, float rotation = 0f) : base(parent)
        {
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }

        public TransformComp(string name, TransformComp? parent, Vector2 position, Vector2 size, float rotation = 0f) : base(parent)
        {
            this.name = name;
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }

        public TransformComp(string name, string tag, TransformComp? parent, Vector2 position, Vector2 size, float rotation = 0f) : base(parent)
        {
            this.name = name;
            this.tag = tag;
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }

        /// <summary>
        /// Gets first child of a certain type. Returns null if none found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>First child of a certain type as a Comp? (cast necessary) or null if not found.</returns>
        public Comp? GetCompByType<T>()
        {
            var childrenOfType = children.OfType<T>();
            return children.Length != 0 ? childrenOfType.FirstOrDefault() as Comp : null;
        }

        /// <summary>
        /// Gets all children of a certain type.
        /// </summary>
        /// <param name="T"></param>
        /// <returns>Array of children of a certain type as a Comp[] (cast necessary) or an empty array if none found.</returns>
        public T[] GetCompsByType<T>()
        {
            return children.OfType<T>().ToArray();
        }

        public override void Strt() { }
        public override void Upd(float dT) { }
    }
}
