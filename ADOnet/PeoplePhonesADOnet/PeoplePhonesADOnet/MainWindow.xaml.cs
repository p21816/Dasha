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

namespace PeoplePhonesADOnet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnectionToDatabase c = new ConnectionToDatabase();
        public MainWindow()
        {
            InitializeComponent();
            Model.PeopleData = c.getInfoFromDataBase();
            PeoplePhonesDatagrid.ItemsSource = Model.PeopleData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            c.setInfoToDataBase();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
