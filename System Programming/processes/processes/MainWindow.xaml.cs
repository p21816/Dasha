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

namespace processes
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ProcessInfo> procesessCollection = new ObservableCollection<ProcessInfo>();
        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = procesessCollection;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessInfo p = new ProcessInfo();
            procesessCollection.Add(p);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProcessInfo p = (ProcessInfo)dg.SelectedItem;
            if (p == null) return;
            p.Kill();
            procesessCollection.Remove(p);
        }
    }
}
