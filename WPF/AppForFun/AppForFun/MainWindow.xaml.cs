using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AppForFun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model m = new Model();
        public MainWindow()
        {
            InitializeComponent();
        }

        #region menuAnimation
        private void img_MouseEnter(object sender, MouseEventArgs e)
        {
            img.Width = 47;
            img.Height = 47;
        }

        private void img_MouseLeave(object sender, MouseEventArgs e)
        {
            img.Width = 40;
            img.Height = 40;
        }

        private void img1_MouseEnter(object sender, MouseEventArgs e)
        {
            img1.Width = 40;
            img1.Height = 40;
        }

        private void img1_MouseLeave(object sender, MouseEventArgs e)
        {
            img1.Width = 35;
            img1.Height = 35;
        }

        #endregion

        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dataGrid.IsEnabled = false;
            dataGrid.Visibility = Visibility.Hidden;

            adder.Visibility = Visibility.Visible;
            adder.IsEnabled = true;
            addUser.Visibility = Visibility.Visible;
            addUser.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            m.records.Add(new User
            {
                FirstName = adder.FirstName,
                LastName = adder.LastName
            });
            adder.RecordClear();
        }

        private void img1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show(m.records[0].FirstName.ToString() + " " + m.records[0].LastName.ToString());
            adder.Visibility = Visibility.Hidden;
            adder.IsEnabled = false;
            addUser.Visibility = Visibility.Hidden;
            addUser.IsEnabled = false;

            dataGrid.IsEnabled = true;
            dataGrid.Visibility = Visibility.Visible;

            dataGrid.ItemsSource = m.records;

        }
    }
}
