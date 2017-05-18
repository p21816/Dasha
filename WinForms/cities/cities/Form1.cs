using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace cities
{
    public partial class Form1 : Form
    {
        XmlDocument instruments = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            instruments.Load("../../instruments.xml");
            var brandNodes = instruments.SelectNodes("instruments/type/name");
            foreach (XmlNode x in brandNodes)
            {
                comboBox2.Items.Add(x.InnerText);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string xpath = "instruments/type[name='" + (string)comboBox2.SelectedItem + "']/models/model/name";
            var modelNodes = instruments.SelectNodes(xpath);
            comboBox1.Items.Clear();
            foreach(XmlNode x in modelNodes)
            {
                comboBox1.Items.Add(x.InnerText);
            }
        }
    }
}
