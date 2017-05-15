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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tree1.Visibility = Visibility.Hidden;
            tree2.Visibility = Visibility.Hidden;
            tree3.Visibility = Visibility.Hidden;
            tree4.Visibility = Visibility.Hidden;
            tree5.Visibility = Visibility.Hidden;
            tree6.Visibility = Visibility.Hidden;
            tree7.Visibility = Visibility.Hidden;
            tree8.Visibility = Visibility.Hidden;
            tree9.Visibility = Visibility.Hidden;
            tree10.Visibility = Visibility.Hidden;
            tree11.Visibility = Visibility.Hidden;
            tree12.Visibility = Visibility.Hidden;
            tree13.Visibility = Visibility.Hidden;
            tree14.Visibility = Visibility.Hidden;


            Eye1.Visibility = Visibility.Visible;
            Eye2.Visibility = Visibility.Visible;
            mouth1.Visibility = Visibility.Visible;
            mouth2.Visibility = Visibility.Visible;
            mouth3.Visibility = Visibility.Visible;
            mouth4.Visibility = Visibility.Visible;
            mouth5.Visibility = Visibility.Visible;
            mouth6.Visibility = Visibility.Visible;
            label1.Content = "smile!";

      
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Eye1.Visibility = Visibility.Hidden;
            Eye2.Visibility = Visibility.Hidden;
            mouth1.Visibility = Visibility.Hidden;
            mouth2.Visibility = Visibility.Hidden;
            mouth3.Visibility = Visibility.Hidden;
            mouth4.Visibility = Visibility.Hidden;
            mouth5.Visibility = Visibility.Hidden;
            mouth6.Visibility = Visibility.Hidden;


            tree1.Visibility = Visibility.Visible;
            tree2.Visibility = Visibility.Visible;
            tree3.Visibility = Visibility.Visible;
            tree4.Visibility = Visibility.Visible;
            tree5.Visibility = Visibility.Visible;
            tree6.Visibility = Visibility.Visible;
            tree7.Visibility = Visibility.Visible;
            tree8.Visibility = Visibility.Visible;
            tree9.Visibility = Visibility.Visible;
            tree10.Visibility = Visibility.Visible;
            tree11.Visibility = Visibility.Visible;
            tree12.Visibility = Visibility.Visible;
            tree13.Visibility = Visibility.Visible;
            tree14.Visibility = Visibility.Visible;
            label1.Content = "Merry Christmas!!!";
        }


    }
}
