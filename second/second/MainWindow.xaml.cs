using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace second
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly bool initialized = false;
        public MainWindow()
        {
            InitializeComponent();
            boxx.Fill = new SolidColorBrush(Colors.Black);
            (new List<string>() {
            "aaa","bb","cc","dd","eee"
            }).ForEach(new Action<string>(x => listBox.Items.Add(x)));
            initialized = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string selectedItem = listBox.SelectedItem.ToString();
                listBox.Items.Insert(0, selectedItem);
                int index = listBox.SelectedIndex;
                listBox.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Выберете элемент, который хотите перенести!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string selectedItem = listBox.SelectedItem.ToString();
                listBox.Items.Insert(listBox.Items.Count, selectedItem);
                int index = listBox.SelectedIndex;
                listBox.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Выберете элемент, который хотите перенести!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string selectedItem = listBox.SelectedItem.ToString();
                int index = listBox.SelectedIndex;
                if (index > 0)
                {
                    listBox.Items.Insert(index - 1, selectedItem);
                    listBox.Items.RemoveAt(index + 1);
                }

            }
            else
            {
                MessageBox.Show("Выберете элемент, который хотите перенести!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string selectedItem = listBox.SelectedItem.ToString();
                int index = listBox.SelectedIndex;
                if(index < listBox.Items.Count-1)
                {
                    listBox.Items.RemoveAt(index);
                    listBox.Items.Insert(index + 1, selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Выберете элемент, который хотите перенести!");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (initialized)
            boxx.Fill = new SolidColorBrush(Colors.Pink);
        }


    }
}
