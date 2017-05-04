using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraphicEditor
{
    public partial class Form1 : Form
    {

        Pen p = new Pen(Brushes.Aqua);
        Rectangle chosenRectangle = new Rectangle();
        Point mouseClick;
        int index = -1;

        List<Rectangle> rect = new List<Rectangle>();

        public Form1()
        {
            InitializeComponent();
            rect.Add(new Rectangle(10, 10, 30, 40));
            rect.Add(new Rectangle(50, 50, 100, 150));
            rect.Add(new Rectangle(160, 160, 50, 70));
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           mouseClick = e.Location;
           if (isInside() != -1)
           {
              chosenRectangle = rect[isInside()];
              index = isInside();
           }
        }

        private int isInside()
        {
            int num = 0;
            foreach (Rectangle r in rect)
            {
                if (r.Contains(mouseClick)) return num;
                num++;
            }
            return -1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            p.Width = 1;
            //Point point1 = new Point(50, 50);
            //Point point2 = new Point(100, 25);
            //Point point3 = new Point(200, 50);
            //Point[] curvePoints =
            // {
            //     point1,
            //     point2,
            //     point3
            // };

            foreach(Rectangle r in rect)
            {
                e.Graphics.DrawRectangle(p, r);

                //e.Graphics.DrawPolygon(p, curvePoints);
            }

            //e.Graphics.DrawEllipse(p,
            //     new Rectangle(10 , 10, 50, 50));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (index != -1)
            {
                rect[index] = new Rectangle(e.Location.X - mouseClick.X + chosenRectangle.X, e.Location.Y - mouseClick.Y + chosenRectangle.Y, chosenRectangle.Width, chosenRectangle.Height);
                this.Invalidate();
                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(index != -1)
            {
                index = -1;
            }
        }
    }
}
