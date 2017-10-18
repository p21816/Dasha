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
using System.Windows.Threading;

namespace CountersMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static ObservableCollection<ProcessInfo> pc = new ObservableCollection<ProcessInfo>();
        internal static Dispatcher dispatcher;
        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = pc;
            dispatcher = Dispatcher;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pc.Add(new ProcessInfo());
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg.SelectedItem == null)
                {
                    return;
                }
                (dg.SelectedItem as ProcessInfo).Priority++;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // INGORE
            }
        }

        private void KillButtonClick(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                return;
            }
            var pi = dg.SelectedItem as ProcessInfo;
            pi.Kill();
            pc.Remove(pi);
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg.SelectedItem == null)
                {
                    return;
                }
                (dg.SelectedItem as ProcessInfo).Priority--;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // INGORE
            }
        }
    }
}
