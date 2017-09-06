using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SemaphoreWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Workers w = new Workers();
            Workers w1 = new Workers();
            Workers w2 = new Workers();
            Workers w3 = new Workers();

            Thread th = new Thread(w.WorkingThread);
            Thread th1 = new Thread(w1.WorkingThread);
            Thread th2 = new Thread(w2.WorkingThread);
            Thread th3 = new Thread(w3.WorkingThread);

            th.Start();
            th1.Start();
            th2.Start();
            th3.Start();


        }
    }
}
