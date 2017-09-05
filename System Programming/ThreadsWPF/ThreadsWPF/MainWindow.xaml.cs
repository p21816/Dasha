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

namespace ThreadsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            long maxNumber = 1000000000;
            long res = 0;

            sumTask s = new sumTask(0,25);
            Thread th = new Thread(s.Calculate);

            sumTask s1 = new sumTask(25, 50);
            Thread th1 = new Thread(s1.Calculate);

            sumTask s2 = new sumTask(50, 75);
            Thread th2 = new Thread(s2.Calculate);

            sumTask s3 = new sumTask(75, 100);
            Thread th3 = new Thread(s3.Calculate);

            th.Start();

            th1.Start();

            th2.Start();

            th3.Start();

            th.Join();
            th1.Join();
            th2.Join();
            th3.Join();

            res = s.result + s1.result + s2.result + s3.result;
            MessageBox.Show(res.ToString());


        }
    }

    public class sumTask
    {
        public sumTask(long f, long t)
        {
            from = f;
            to = t;
        }
        public readonly long from, to;
        public long result { get; private set; }
        public void Calculate()
        {
            for (long i = from; i <= to; i++)
            {
                result += i;
            }
        }
    }

}
