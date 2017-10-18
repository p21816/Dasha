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
using System.Configuration;
using System.Threading;

namespace BT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int LastProcessedId;
        public MainWindow()
        {
            InitializeComponent();
            LastProcessedId = Convert.ToInt32(ConfigurationManager.AppSettings["LastProcessedId"] ?? "0");
            MessageBox.Show(LastProcessedId.ToString());

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 2);
            dt.Tick += dt_Tick;
            dt.Start();
        }

       static public BankTransfersModelContainer conn = new BankTransfersModelContainer();
       static public DashkasBankEntities DashkConn = new DashkasBankEntities();

       void dt_Tick(object sender, EventArgs e)
       {
           var messages = from m in conn.MessageSet where (m.RecieverBankId == 42 && m.Id > LastProcessedId) select m;
           foreach (var m in messages)
           {
                   m.Process();
                   LastProcessedId = m.Id;
                   AddUpdateAppSettings("LastProcessedId", LastProcessedId.ToString());
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
            //for(int i = 0; i < 10; i++)
            //{
                PaymentMessage pm = new PaymentMessage()
                {
                    RecieverBankId = Convert.ToInt32(RecBankIdTextBox.Text),
                    RecieverAccountId = Convert.ToInt32(RecieverNumTextBox.Text),
                    SenderAccountId = Convert.ToInt32(SenderNumTextBox.Text),
                    Amount = Convert.ToInt32(SumTextBox.Text),
                    SenderBankId = 42
                };
                conn.MessageSet.Add(pm);
            //}
            conn.SaveChanges();
        }



        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        //Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                        string str = "Key: {0} Value: {1} " + key + appSettings[key];
                        MessageBox.Show(str);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
        }

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }


    }





}
