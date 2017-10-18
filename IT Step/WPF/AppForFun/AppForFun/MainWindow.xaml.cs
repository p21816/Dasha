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

namespace ExamWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model m = new Model();
        bool f = true;
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
        private void img2_MouseEnter(object sender, MouseEventArgs e)
        {
            img2.Width = 40;
            img2.Height = 40;
        }

        private void img2_MouseLeave(object sender, MouseEventArgs e)
        {
            img2.Width = 35;
            img2.Height = 35;
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Car c = new Car();
            c.Mark = adder.CarMark;
            c.CarName = adder.CarName;
            c.Price = adder.CarPrice;
            if (m.IsValid(c) && f) m.cars.Add(c);
            else if (f) MessageBox.Show("Такая машина уже существует");
            else if (m.IsValid(c) && !f)
            {
                m.cars.RemoveAt(0);
            }
            adder.RecordClear();
        }

        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dataGrid.IsEnabled = false;
            dataGrid.Visibility = Visibility.Hidden;

            adder.Visibility = Visibility.Visible;
            adder.IsEnabled = true;
            addCar.Visibility = Visibility.Visible;
            addCar.IsEnabled = true;
            addCar.Content = "Добавить";
            f = true;
        }
        private void img1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show(m.records[0].FirstName.ToString() + " " + m.records[0].LastName.ToString());
            adder.Visibility = Visibility.Hidden;
            adder.IsEnabled = false;
            addCar.Visibility = Visibility.Hidden;
            addCar.IsEnabled = false;

            dataGrid.IsEnabled = true;
            dataGrid.Visibility = Visibility.Visible;

            dataGrid.ItemsSource = m.cars;

        }
        private void img2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dataGrid.IsEnabled = false;
            dataGrid.Visibility = Visibility.Hidden;

            adder.Visibility = Visibility.Visible;
            adder.IsEnabled = true;
            addCar.Visibility = Visibility.Visible;
            addCar.IsEnabled = true;
            addCar.Content = "Удалить";
            f = false;
        }


    }
}
