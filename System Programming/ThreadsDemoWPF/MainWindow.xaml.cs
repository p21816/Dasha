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
using System.Windows.Threading;

namespace ThreadsDemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<string> sl = new List<string>();
        int lastAddedStringNumber = -1;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer t = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 200),
                IsEnabled = true,
            };
            t.Tick += t_Tick;
        }




        #region backgroundFibo

        void t_Tick(object sender, EventArgs e)
        {
            for (int i = lastAddedStringNumber + 1; i < sl.Count; i++)
            {
                outBox.Items.Add(sl[i]);
                lastAddedStringNumber = i;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread calculator = new Thread(
                () =>
                {

                    Random r = new Random();
                    DateTime start = DateTime.Now;
                    for (int i = 0; i < 10; i++)
                    {
                        int n = r.Next(34, 40);
                        sl.Add(String.Format("{0} {1}", n, FiboMaker.Fibo(n)));
                    }
                    sl.Add(String.Format("time = {0:#.##}", (DateTime.Now - start).TotalSeconds));
                }
            );
            calculator.Start();
        }

        #endregion


        int counter;
        int counts = 100000000;
        int chunk = 200000;

        object lockObject = new object();

        void inc(object input)
        {
            for (int i = 0; i < counts/chunk; i++)
            {
                int ooo=0;
                for (int j = 0; j < chunk; j++)
                {
                    ooo++;
                }
//                counter+=ooo;
                Interlocked.Add(ref counter, ooo);
                //Interlocked.Increment(ref counter);
            }
        }
        void dec(object input)
        {
            int param = (int)input;
            for (int i = 0; i < counts / chunk; i++)
            {
                int ooo = 0;
                for (int j = 0; j < chunk; j++)
                {
                    ooo--;
                }
                //counter += ooo;
                Interlocked.Add(ref counter, ooo);
                //Interlocked.Decrement(ref counter);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            counter = 0;
            DateTime start = DateTime.Now;
            Thread t1 = new Thread(inc);
            Thread t2 = new Thread(dec);
            t1.Start(0);
            t2.Start(1);
            t1.Join();
            t2.Join();
            
            sl.Add(String.Format("time = {0:#.##} res = {1}", (DateTime.Now - start).TotalSeconds,counter));

        }
    }

    public class SumTask
    {
        public readonly int from, to;
        public int result { get; private set; }
        void Calculate() {
            for (int i = from ; i < to; i++)
            {
                
            }
        }
    }

    public static class FiboMaker
    {
        // O(2^N)
        static public int Fibo(int n)
        {
            if (n < 2) return 1;
            return Fibo(n - 1) + Fibo(n - 2);
        }
    }
}
