using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEllipses
{
    public class Ellipse:Shape
    {

        public float rx;
        public float ry;
        public Ellipse(Model m, float x, float y, float rx, float ry) 
            : base(m, x, y)
        {
            
            this.rx = rx;
            this.ry = ry;
        }

        public Ellipse(Model model, System.Xml.XmlElement el): base(model, 0, 0)
        {
            position.X = Convert.ToSingle(el.Attributes["cx"].Value);
            position.Y = Convert.ToSingle(el.Attributes["cy"].Value);
            rx = Convert.ToSingle(el.Attributes["rx"].Value);
            ry = Convert.ToSingle(el.Attributes["ry"].Value);
        }
        public override bool isInside(System.Drawing.PointF p)
        {
            if (Sqr(p.X - position.X) / Sqr(rx) +
                Sqr(p.Y - position.Y) / Sqr(ry) < 1)
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
            model.sp.DrawEllipse(this, gr);
        }

        public override string ToSVG()
        {
            string temp = String.Format(@"<ellipse cx='{0}' cy='{1}' rx='{2}' ry='{3}'
  style='fill:{4};stroke:{5};stroke-width:{6}' />", position.X, position.Y, rx, ry, ((SolidBrush)b).Color, p.Color, p.Width);
            return temp;
        }
    }
}
