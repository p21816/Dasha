using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programm_guessing_your_number
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game();
        }

        private void game() // код игры, использующий бинарный поиск
        {
            int number = 0;
            int first = 0;
            int last = 2000;
            int average;
            int count = 0;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Вы загадали " + number + "?", " ", buttons);
            count++;
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Я угадал! =) ура!!! мне потребовалось для этого вот такое количество запросов к тебе, человек: " + count);
            }

            if (result == DialogResult.No)
            {
                while (first < last)
                {
                    average = first + (last - first) / 2;
                    DialogResult result0 = MessageBox.Show("Вы загадали " + average + "?", " ", buttons);
                    count++;
                    if (result0 == DialogResult.Yes)
                    {
                        break;
                    }

                    DialogResult result1 = MessageBox.Show("Загаданное вами число больше?", " ", buttons);
                    count++;
                    if (result1 == DialogResult.Yes)
                    {
                        first = average + 1;
                    }
                    else
                    {
                        last = average;
                    }
                }
            }
            MessageBox.Show("Я угадал! =) ура!!! мне потребовалось для этого вот такое количество запросов к тебе, человек: " + count);
            DialogResult res = MessageBox.Show("Желаете сыграть еще раз?", " ", buttons);
            if (res == DialogResult.Yes)
            {
                game();
            }
        }
    }
}
