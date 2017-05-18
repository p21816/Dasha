using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImaginaryRectangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int h = this.ClientSize.Height; 
            int w = this.ClientSize.Width;
            int x = e.Location.X;
            int y = e.Location.Y;
            
            //закрывает приложение при нажатии мыши + ctrl
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) Application.Exit();

            //выводит в заголовок формы ширину и высоту рабочей облати формы
            if (e.Button == MouseButtons.Right)
            {
                this.Text = "ширина = " + h + ", высота = " + w;
            }

            //определяет где относительно воображаемого прямоугольника был щелчок мыши
            if (y > (h - 10) || y < 10 || x > (w - 10) || x < 10) MessageBox.Show("курсор снаружи воображаемого прямоугольника");
            else if (y == (h - 10) || y == 10 || x == (w - 10)) MessageBox.Show("курсор на границе воображаемого прямоугольника");
            else MessageBox.Show("курсор внутри воображаемого прямоугольника");
        }

        //выводит в заголовок формы текущие координаты мыши
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X.ToString() + ", " + e.Y.ToString();
        }
    }
}
