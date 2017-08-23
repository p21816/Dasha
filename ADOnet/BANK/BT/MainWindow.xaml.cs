using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BT
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

        BankTransfersModelContainer conn = new BankTransfersModelContainer();
        DashkasBankEntities DaskConn = new DashkasBankEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conn.MessageSet.Load();
            DaskConn.Account.Load();
            dg.ItemsSource = DaskConn.Account.Local;
            dg1.ItemsSource = conn.MessageSet.Local;
        }
    }
}
