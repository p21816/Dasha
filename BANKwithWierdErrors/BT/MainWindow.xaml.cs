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
using System.Windows.Threading;

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
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0,0,10);
            dt.Tick += dt_Tick;
            dt.Start();
        }

       static public BankTransfersModelContainer conn = new BankTransfersModelContainer();
       static public DashkasBankEntities DashkConn = new DashkasBankEntities();

        void dt_Tick(object sender, EventArgs e)
        {
            conn.MessageSet.Load();
            var messages = from m in conn.MessageSet.Local where m.RecieverBankId == 42 select m;
           foreach(var m in messages)
           {
               m.Process();
           }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conn.MessageSet.Load();
            DashkConn.Account.Load();
            dg.ItemsSource = DashkConn.Account.Local;
            dg1.ItemsSource = conn.MessageSet.Local;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PaymentMessage pm = new PaymentMessage() { RecieverBankId = Convert.ToInt32(RecBankIdTextBox.Text) , 
                RecieverAccountId = Convert.ToInt32(RecieverNumTextBox.Text) , 
                SenderAccountId =Convert.ToInt32(SenderNumTextBox.Text) , 
                Amount = Convert.ToInt32(SumTextBox.Text) , SenderBankId = 42 
        };
            conn.MessageSet.Add(pm);
            conn.SaveChanges();
        }
    }
}
