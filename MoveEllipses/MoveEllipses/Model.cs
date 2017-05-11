using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace MoveEllipses
{
    public class Model
    {
        public IShapesPainter sp;
        public List<Shape> shapes = new List<Shape>();

        public Shape SelectedShape
        {
            private set;
            get;
        }

        public Model(IShapesPainter sp, XmlDocument doc)
        {
            this.sp = sp;

            foreach(XmlElement el in doc.SelectNodes("//rect")) {
                shapes.Add(new Rectangle(this, el));
            }
            foreach (XmlElement el in doc.SelectNodes("//ellipse"))
            {
                shapes.Add(new Ellipse(this, el));
            }
        }

        public void addEllipse(float x, float y, float rx, float ry)
        {
            shapes.Add(new Ellipse(this, x, y, rx, ry));
        }
        public void addRectangle(float x, float y, float w, float h)
        {
            shapes.Add(new Rectangle(this, x, y, w, h));
        }

        public Model(IShapesPainter sp)
        {
            this.sp = sp;
        }

        public void Paint(Graphics gr)
        {
            foreach (Shape s in shapes)
            {
                s.Paint(gr);
            }
        }

        public Shape SelectShape(float x, float y)
        {
            Shape candidate = null;
            foreach (Shape s in shapes)
            {
                if (s.isInside(new PointF(x, y)))
                {
                    candidate = s;
                }
            }
            SelectedShape = candidate;
            return SelectedShape;
        }




        internal void MoveSelectionToFront()
        {
            int index = shapes.IndexOf(SelectedShape);
            if (index == shapes.Count - 1)
            {
                return;
            }
            var temp = shapes[index];
            shapes[index] = shapes[index + 1];
            shapes[index + 1] = temp;
        }

        internal void MoveSelectionBehind()
        {
            int index = shapes.IndexOf(SelectedShape);
            if (index == 0)
            {
                return;
            }
            var temp = shapes[index];
            shapes[index] = shapes[index - 1];
            shapes[index - 1] = temp;
        }
        internal void DeleteSelection()
        {
            shapes.Remove(SelectedShape);
        }

        public void SaveToFile()
        {
            //FileStream file = new FileStream(@"D:\Averina\WinForms\Shapes\MoveEllipses\ShapesFile.svg", FileMode.Create);
            //file.Write();
            StreamWriter shapesFile = new StreamWriter(@"D:\Averina\WinForms\Shapes\MoveEllipses\ShapesFile.svg");
            shapesFile.Write(@"<svg width='1000' height='100'>");
            foreach(Shape s in shapes)
            {
                shapesFile.WriteLine(s.ToSVG());
            }
            shapesFile.Write(@"</svg>");
            shapesFile.Close();

        }
    }
}
