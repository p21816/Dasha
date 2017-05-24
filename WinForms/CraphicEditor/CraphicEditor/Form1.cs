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
        Pen circlePen = new Pen(Brushes.DeepPink);

        Rectangle chosenRectangle = new Rectangle();
        Point mouseClick;
        int index = -1;
        int indexOfElToDel = -1;
        bool elToAdd = false;

        List<Rectangle> rect = new List<Rectangle>();
        Timer animationTimer = new Timer();
        Color selectionColor = Color.FromArgb(144, 0, 255);
        double t;
        int green;

        List<Rectangle> ellipses = new List<Rectangle>();
        Rectangle chosenEllipse = new Rectangle();

        public Form1()
        {
            InitializeComponent();
            rect.Add(new Rectangle(10, 10, 30, 40));
            rect.Add(new Rectangle(50, 50, 100, 150));
            rect.Add(new Rectangle(160, 160, 50, 70));

            ellipses.Add(new Rectangle(100, 100, 90, 40));
            ellipses.Add(new Rectangle(130, 300, 40, 40));

            animationTimer.Interval = 40;
            animationTimer.Tick += animationTimer_Tick;
            animationTimer.Start();
        }

        void animationTimer_Tick(object sender, EventArgs e)
        {
            t += 0.2;
            green = (int)(128 + 127 * Math.Sin(t));


            selectionColor = Color.FromArgb(144, green, 255);
            this.Invalidate();
            this.Update();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClick = e.Location;
            if (isInside() != -1)
            {
                index = isInside();
                indexOfElToDel = isInside();
                chosenRectangle = rect[indexOfElToDel];
               // chosenEllipse = ellipses[index];
                this.Invalidate();
                this.Update();
            }
        }

        private int isInside()
        {
            int num = 0;
            foreach (Rectangle r in rect)
            {
                if (r.Contains(mouseClick))
                    return num;
                    num++;
                
            }

            //foreach (Rectangle el in ellipses)
            //{
            //    if (el.Contains(mouseClick))
            //    {
            //        return num;
            //        num++;
            //    }
            //}
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

            foreach (Rectangle r in rect)
            {
                if (r == chosenRectangle)
                {
                    p.Color = selectionColor;
                }
                e.Graphics.DrawRectangle(p, r);
                p.Color = Color.Aqua;
            }
            //e.Graphics.DrawPolygon(p, curvePoints);
            foreach (Rectangle el in ellipses)
            {
                e.Graphics.DrawEllipse(p, el);
            }

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
            index = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Color = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (indexOfElToDel != -1)
            {
                rect.RemoveAt(indexOfElToDel);
                this.Invalidate();
                this.Update();
                indexOfElToDel = -1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rect.Add(new Rectangle(10, 10, 20, 20));
            this.Invalidate();
            this.Update();
        }
    }
}
