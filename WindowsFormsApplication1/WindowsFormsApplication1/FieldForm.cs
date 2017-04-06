using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FieldForm : Form
    {
        const int maxDigits = 8;
        public FieldForm()
        {
            InitializeComponent();
            redButton.Tag = Color.Red;
            greenButton.Tag = Color.Green;
            blueButton.Tag = Color.Blue;
        }

        private void FieldForm_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var control = (Control)sender;
            // берем ее тэг как строку
            var color = (Color)control.Tag;
            // используем нулевой символ
            panel1.BackColor = color;
            ////смотрим какая кнопка нажата
            //var control = (Control)sender;
            //// берем ее тэг как строку
            //var tagString = (string)control.Tag;
            //// используем нулевой символ
            //AddDigit(tagString[0]);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var control = (Control)sender;
            var tagString = (string)control.Tag;
            changeToEnglish(tagString[0]);

        }

        private void changeToEnglish(char lan)
        {
            if(lan == 'E')
            {
                redButton.Text = "red";
                greenButton.Text = "green";
                blueButton.Text = "blue";
            }
            if(lan == 'D')
            {
                redButton.Text = "rot";
                greenButton.Text = "grun";
                blueButton.Text = "blau";
            }
            if(lan == 'R')
            {
                redButton.Text = "красный";
                greenButton.Text = "зеленый";
                blueButton.Text = "синий";
            }

        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value,BlueTrackBar.Value);
            string name = RedTrackBar.Value.ToString();
            RedTextBox.Text = name;
            string name1 = GreenTrackBar.Value.ToString();
            GreenTextBox.Text = name1;
            string name2 = BlueTrackBar.Value.ToString();
            BlueTextBox.Text = name2;

        }

        private void BlueTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value;
                int val;

                value = RedTextBox.Text;
                val = Int32.Parse(value);
                RedTrackBar.Value = val;

                value = GreenTextBox.Text;
                val = Int32.Parse(value);
                GreenTrackBar.Value = val;

                value = BlueTextBox.Text;
                val = Int32.Parse(value);
                BlueTrackBar.Value = val;

            }
        }

        private void RedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value;
                int val;

                value = RedTextBox.Text;
                val = Int32.Parse(value);
                RedTrackBar.Value = val;
            }
        }

        private void GreenTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value;
                int val;

                value = GreenTextBox.Text;
                val = Int32.Parse(value);
                GreenTrackBar.Value = val;
            }
        }

        private void BlueTextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value;
                int val;

                value = BlueTextBox.Text;
                val = Int32.Parse(value);
                BlueTrackBar.Value = val;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstMessage = "Мое резюме";
            string secondMessage = "Мое резюмешечко";
            string thirdMessage = "Мое резюме2";
            int fullLength = firstMessage.Length + secondMessage.Length + thirdMessage.Length;
            int count = 0;

            MessageBox.Show(firstMessage);
            count++;
            MessageBox.Show(secondMessage);
            count++;
            MessageBox.Show(thirdMessage, "среднее число символов на странице: " +   fullLength / ++count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number;
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            MessageBox.Show("Вы загадали 1000?","Угадайка", buttons);
        }


    }
}
