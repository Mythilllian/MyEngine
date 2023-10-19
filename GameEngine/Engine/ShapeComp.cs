using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Drawing;

namespace GameEngine.Engine
{
    public class ShapeComp : ImageComp
    {
        private Shape _shape = new Shape();
        public Shape shape { 
            get 
            { 
                return _shape; 
            } 
            set 
            {
                //Sets shape and converts into image and sets image
                _shape = value;
                Bitmap bitmap = new Bitmap((int)_shape.size.x, (int)_shape.size.y);
                using(Graphics e = Graphics.FromImage(bitmap))
                using(Brush brush = new SolidBrush(_shape.fillColor))
                using(Pen pen = new Pen(_shape.outline.Item1, _shape.outline.Item2))
                {
                    e.Clear(Color.Transparent);
                    {
                        if (_shape.shapeType == ShapeType.Circle)
                        {
                            e.FillEllipse(brush,0,0, _shape.size.x, _shape.size.y);
                            e.DrawEllipse(pen, 0, 0, _shape.size.x, _shape.size.y);
                        }
                        else
                        {
                            e.FillRectangle(brush,0,0, _shape.size.x, _shape.size.y);
                            e.DrawRectangle(pen, 0, 0, _shape.size.x, _shape.size.y);
                        }
                    }
                }
                img = bitmap;
            } 
        }
    }

    public struct Shape
    {
        public ShapeType shapeType;
        public Vector2 size;
        public Color fillColor;
        public (Color,int) outline;

        public Shape(ShapeType shapeType = ShapeType.Rectangle, Vector2 size = default(Vector2), Color fillColor = default(Color), Color outlineColor = default(Color), int outlineThickness = 0)
        {
            this.shapeType = shapeType;
            this.size = size != default(Vector2) ? size : Vector2.One;
            this.fillColor = fillColor != default(Color) ? fillColor : Color.Black;
            outline.Item1 = outlineColor != default(Color) ? outlineColor : Color.Black;
            outline.Item2 = outlineThickness;
        }
    }

    public enum ShapeType
    {
        Rectangle,
        Circle
    }
}
