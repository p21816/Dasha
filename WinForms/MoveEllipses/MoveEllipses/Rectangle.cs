using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEllipses
{
    public class Rectangle: Shape
    {
        public float width;
        public float height;
        public Rectangle(Model m, float x, float y, float width, float height) 
            : base(m, x, y)
        {

            this.width = width;
            this.height = height;
        }

        public Rectangle(Model model, System.Xml.XmlElement el) :
            base(model,0,0)
        {
            position.X = Convert.ToSingle(el.Attributes["x"].Value);
            position.Y = Convert.ToSingle(el.Attributes["y"].Value);
            width = Convert.ToSingle(el.Attributes["width"].Value);
            height = Convert.ToSingle(el.Attributes["height"].Value);
        }
        public override bool isInside(System.Drawing.PointF p)
        {
            if ((p.X > position.X) && (p.X < position.X + width) &&
                (p.Y > position.Y) && (p.Y < position.Y + height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool isOnBorder(System.Drawing.PointF p)
        {
            return false;
        }

        public override void Paint(Graphics gr)
        {
            model.sp.DrawRectangle(this, gr);
        }

        public override string ToSVG()
        {
            string temp = String.Format(@"<rect x='{0}' y='{1}' width='{2}' height='{3}'
  style='fill:{4};stroke:{5};stroke-width{6};fill-opacity:0.1;stroke-opacity:0.9' />",position.X, position.Y , width, height, ((SolidBrush)b).Color  , p.Color, p.Width );
            return temp;
        }
    }
}
