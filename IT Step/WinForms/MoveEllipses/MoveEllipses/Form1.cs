using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MoveEllipses
{
    public partial class Form1 : Form, IShapesPainter
    {
        Model m;
        Timer animationTimer = new Timer();
        Color selectionColor = Color.FromArgb(144, 0, 255);
        double t;
        int green;
        Control workspace;
        int MoveToRight = 200;

        public Form1()
        {
            InitializeComponent();
            workspace = this;
            button6.Image = Image.FromFile("..\\..\\ellipse.jpg");
            button7.Image = Image.FromFile("..\\..\\square.jpg");
            button3.Image = Image.FromFile("..\\..\\up.jpg");
            button4.Image = Image.FromFile("..\\..\\down.jpg");
            button5.Image = Image.FromFile("..\\..\\delete.jpg");

            this.workspace.Paint += new System.Windows.Forms.PaintEventHandler(this.workspace_Paint);
            this.workspace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseDown);
            this.workspace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseMove);

            m = new Model(this);
            panelForCoords.Visible = false;
            SetPanel();          
            m.addEllipse(100, 100, 50, 70);
            m.addEllipse(200, 100, 40, 70);
            m.addEllipse(100, 200, 50, 40);
            m.addRectangle(150, 150, 100, 70);
            animationTimer.Interval = 40;
            animationTimer.Tick += animationTimer_Tick;
            animationTimer.Start();
        }

        void animationTimer_Tick(object sender, EventArgs e)
        {
            t += 0.2;
            green = (int)(128 + 127 * Math.Sin(t));
            selectionColor = Color.FromArgb(144, green, 255);
            workspace.Invalidate();
            workspace.Update();
        }

        private void SetPanel()
        {
            Label l1 = new Label();
            l1.Location = new Point(10, 10);
            l1.Text = "Position X";
            l1.Width = 70;
            TextBox box1 = new TextBox();
            box1.Location = new Point(10, 35);
            box1.Width = 70;

            Label l2 = new Label();
            l2.Location = new Point(10, 70);
            l2.Text = "Position Y";
            l2.Width = 70;
            TextBox box2 = new TextBox();
            box2.Location = new Point(10, 95);
            box2.Width = 70;

            Label l3 = new Label();
            l3.Location = new Point(100, 10);
            l3.Text = "Width";
            l3.Width = 70;
            TextBox box3 = new TextBox();
            box3.Location = new Point(100, 35);
            box3.Width = 70;

            Label l4 = new Label();
            l4.Location = new Point(100, 70);
            l4.Text = "Height";
            l4.Width = 70;
            TextBox box4 = new TextBox();
            box4.Location = new Point(100, 95);
            box4.Width = 70;

            panelForCoords.Height = panelForCoords.Height + 40;

            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(60, 130);
            applyButton.Click += ApplyButton_Click;

            panelForCoords.Controls.AddRange(new Control[] { l1, box1, l2, box2, l3, box3, l4, box4, applyButton });
        }


        public void DrawEllipse(Ellipse el, Graphics g)
        {
           // Graphics g = workspace.CreateGraphics();
            g.FillEllipse(el.b,
                el.position.X - el.rx,
                el.position.Y - el.ry,
                2 * el.rx,
                2 * el.ry
                );
            if(el == m.SelectedShape)
            {
                Pen ppp = new Pen(Color.Red);
                ppp.Color = selectionColor;
                g.DrawEllipse(ppp,
                el.position.X - el.rx,
                el.position.Y - el.ry,
                2 * el.rx,
                2 * el.ry
                );
            }
            else
            {
                g.DrawEllipse(el.p,
                el.position.X - el.rx,
                el.position.Y - el.ry,
                2 * el.rx,
                2 * el.ry
                );
            }
        }

        public void DrawRectangle(Rectangle r , Graphics g)
        {
           // Graphics g = workspace.CreateGraphics();
            g.FillRectangle(r.b,
                r.position.X,
                r.position.Y,
                r.width,
                r.height
                );

            if (r == m.SelectedShape)
            {
                Pen ppp = new Pen(Color.Red);
                ppp.Color = selectionColor;
                g.DrawRectangle(ppp,
                r.position.X,
                r.position.Y,
                r.width,
                r.height
                );
            }
            else
            {
                g.DrawRectangle(r.p,
                r.position.X,
                r.position.Y,
                r.width,
                r.height
                );
            }
        }

        private void workspace_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphicsContext currentContext;
            BufferedGraphics buffer;
            currentContext = BufferedGraphicsManager.Current;
            buffer = currentContext.Allocate(e.Graphics, workspace.DisplayRectangle);
            buffer.Graphics.Clear(SystemColors.Control);
            //e.Graphics.Clear(SystemColors.Control);
            buffer.Graphics.TranslateTransform(MoveToRight, 0);
            m.Paint(buffer.Graphics);
            buffer.Render();
            //buffer.Graphics.
            buffer.Dispose();
        }

        private void workspace_MouseDown(object sender, MouseEventArgs e)
        {
            PointF hvatalka = new PointF(e.Location.X - MoveToRight, e.Location.Y);
            if (m.SelectShape(hvatalka.X, hvatalka.Y) != null)
            {
                this.Text = "выбран " + m.SelectedShape.ToString();
                prevMouseCoords = hvatalka;
            }
            else
            {
                this.Text = "ничего не выбрано ";
            }
            workspace.Update();
            workspace.Update();
        }

        PointF prevMouseCoords;
        private void workspace_MouseMove(object sender, MouseEventArgs e)
        {
            PointF hvatalka = new PointF(e.Location.X - MoveToRight, e.Location.Y);
            if ((m.SelectedShape == null) || (e.Button != MouseButtons.Left))
            {
                return;
            }
            float deltax = hvatalka.X - prevMouseCoords.X;
            float deltay = e.Location.Y - prevMouseCoords.Y;
            prevMouseCoords = hvatalka;
            m.SelectedShape.MoveBy(deltax, deltay);
            workspace.Invalidate();
            workspace.Update();
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ru-RU");
        }


  
        private void ChangeLanguage(string lang)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            foreach (Control c in panel1.Controls)
            {
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
        //Up button
        private void button3_Click(object sender, EventArgs e)
        {
            if (m.SelectedShape != null)
            {
                m.MoveSelectionToFront();
            }
            workspace.Invalidate();
            workspace.Update();
        }
        //Down button
        private void button4_Click(object sender, EventArgs e)
        {
            if (m.SelectedShape != null)
            {
                m.MoveSelectionBehind();
            }
            workspace.Invalidate();
            workspace.Update();
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m.SelectedShape != null)
            {
                ColorDialog dialog = new ColorDialog();
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    m.SelectedShape.b = new SolidBrush(dialog.Color);
                }
                workspace.Invalidate();
                workspace.Update();
            }
        }
        //delete shape button
        private void button5_Click(object sender, EventArgs e)
        {
            if (m.SelectedShape != null)
            {
                m.DeleteSelection();
                workspace.Invalidate();
                workspace.Update();
            }
        }
       

        //Add ellipse button
        private void button6_Click(object sender, EventArgs e)
        {
            buttonFlag = false;
            panelForCoords.Show();
            panelForCoords.BringToFront();
        }
        //Add rectangle button
        private void button7_Click(object sender, EventArgs e)
        {
             buttonFlag = true;
            panelForCoords.Show();
            panelForCoords.BringToFront();
        }

        bool buttonFlag = true;

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                float x = (float)Convert.ToDouble(panelForCoords.Controls[1].Text);
                float y = (float)Convert.ToDouble(panelForCoords.Controls[3].Text);
                float w = (float)Convert.ToDouble(panelForCoords.Controls[5].Text);
                float h = (float)Convert.ToDouble(panelForCoords.Controls[7].Text);
                if (buttonFlag == true)
                {
                    m.addRectangle(x, y, w, h);
                }
                else m.addEllipse(x, y, w / 2, h / 2);
                panelForCoords.Controls[1].Text = "";
                panelForCoords.Controls[3].Text = "";
                panelForCoords.Controls[5].Text = "";
                panelForCoords.Controls[7].Text = "";
            }
            catch(FormatException)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            
            panelForCoords.Hide();
            workspace.Invalidate();
            workspace.Update();
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m.SaveToFile();
        }

        private void loadFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Averina\WinForms\Shapes\MoveEllipses\ShapesFile.svg");
            m = new Model(this, doc);
            workspace.Invalidate();
            workspace.Update();
        }






    }
}
