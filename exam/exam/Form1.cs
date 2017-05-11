using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam
{
    public partial class Form1 : Form
    {
        Model m;
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            m = new Model();
            m.addAccount(1, 1234567, 3);
            m.addAccount(2 , 7654321, 10);
            m.addAccount(3, 1111111, 50);
            int count = m.accounts.Count;
            for (int i = 1; i <= count; i++ )
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (BankAccount b in m.accounts)
            {
                listBox1.Items.Add(b.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sumOfTransaction;
            try
            {
                sumOfTransaction = Convert.ToInt32(textBox5.Text);
                string cm1 = comboBox1.SelectedItem.ToString();
                string cm2 = comboBox2.SelectedItem.ToString();
                int indexCm1 = Convert.ToInt32(cm1);
                int indexCm2 = Convert.ToInt32(cm2);

                if (sumOfTransaction > m.accounts[indexCm1 - 1].sum)
                {
                    MessageBox.Show("На счете недостаточно средств");
                }
                else if(sumOfTransaction < 0)
                {
                    MessageBox.Show("Сумма должна быть положительной");
                }
                else
                {
                    m.accounts[indexCm1 - 1].sum = m.accounts[indexCm1 - 1].sum - sumOfTransaction;
                    m.accounts[indexCm2 - 1].sum = m.accounts[indexCm2 - 1].sum + sumOfTransaction;
                    listBox1.Items.Clear();
                    foreach (BankAccount b in m.accounts)
                    {
                        listBox1.Items.Add(b.ToString());
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Вы ввели неверную сумму");
            }
            textBox5.Text = "";
        }
    }
}
