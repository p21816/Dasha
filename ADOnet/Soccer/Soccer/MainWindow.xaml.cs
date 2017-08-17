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

namespace Soccer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = @"Data Source=a3-prepod\A203;Initial Catalog=Football;Integrated Security=True";
        Football db = new Football(connectionString);

        public MainWindow()
        {
            InitializeComponent();
            //var winners = from winner in db.CompetitionWinners select winner;
            SoccerDatagrid.ItemsSource = db.CompetitionWinners;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SubmitChanges();
        }
    }
}
