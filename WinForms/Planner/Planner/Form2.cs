using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string task = textBox1.Text;
            DateTime dt = dateTimePicker1.Value;
            string timeTo = comboBox1.SelectedItem.ToString();

            MessageBox.Show(timeTo);
            Close();
        }
    }
}
