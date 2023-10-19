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
        
        public List<Comp> children = new List<Comp>();

        private Vector2 _position = Vector2.Zero;
        public Vector2 position
        { 
            get { return _position; } 
            set 
            {
                Vector2 difference = value - _position;
                
                foreach (var comp in GetCompsByType<TransformComp>())
                {
                    comp.position += difference;
                }
                _position += difference;
            } 
        }

        private Vector2 _size = Vector2.One;
        public Vector2 size
        {
            get { return _size; }
            set
            {
                if (value.x == 0 || value.y == 0 || _size.x == 0 || _size.y == 0) { _size = value;  return; }
                Vector2 quotient = value / _size;
                foreach (var comp in GetCompsByType<TransformComp>())
                {
                    comp.size *= quotient;
                }
                _size *= quotient;
            }
        }

        private float _rotation = 0f;
        public float rotation
        {
            get { return _rotation; }
            set
            {
                float difference = value - _rotation;
                foreach (var comp in GetCompsByType<TransformComp>())
                {
                    comp.rotation += difference;
                }
                _rotation += difference;
                _rotation = (_rotation % 360) + (int)(_rotation / 360) + (_rotation < 0 ? 360 : 0);
            }
        }

        public TransformComp(Vector2 position, Vector2 size, float rotation = 0f) : base()
        {
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }

        public TransformComp(string name, Vector2 position, Vector2 size, float rotation = 0f) : base()
        {
            this.name = name;
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }

        public TransformComp(string name, string tag, Vector2 position, Vector2 size, float rotation = 0f) : base()
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
        /// <returns>First child of a certain type as a Comp? (cast necessary) or default(T) if not found.</returns>
        public T GetCompByType<T>()
        {
            var childrenOfType = children.OfType<T>();
            return children.Count != 0 ? childrenOfType.FirstOrDefault() : default(T);
        }

        /// <summary>
        /// Gets all children of a certain type
        /// </summary>
        /// <param name="T"></param>
        /// <returns>Array of children of a certain type as a Comp[] (cast necessary) or an empty array if none found.</returns>
        public T[] GetCompsByType<T>()
        {
            return children.OfType<T>().ToArray();
        }

        /// <summary>
        /// Adds new component to the TransformComp
        /// </summary>
        /// <param name="comp"></param>
        public Comp AddComp(Comp comp)
        {
            comp.SetParent(this);
            return comp;
        }

        /// <summary>
        /// Adds new component to the TransformComp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comp"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException">Throws if T is not a Comp</exception>
        public T AddComp<T>(Comp comp)
        {
            comp.SetParent(this);
            try
            {
                return (T)Convert.ChangeType(comp, typeof(T));
            }
            catch { throw new InvalidCastException("Type T was not a Comp."); }
        }

        public override void OnParentChange() { }
        public override void OnStart() { }
        public override void OnUpdate(float dT) { }
    }
}
