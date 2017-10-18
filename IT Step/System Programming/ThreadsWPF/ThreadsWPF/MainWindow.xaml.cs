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
    // вычисляем сумму чисел от 0 до 100 (должно получиться 5050)
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            long res = 0;

            //создаем объект класса sumTask и новый поток для каждого объекта
            sumTask s = new sumTask(0,25);
            Thread th = new Thread(s.Calculate);

            sumTask s1 = new sumTask(26, 50);
            Thread th1 = new Thread(s1.Calculate);

            sumTask s2 = new sumTask(51, 75);
            Thread th2 = new Thread(s2.Calculate);

            sumTask s3 = new sumTask(76, 100);
            Thread th3 = new Thread(s3.Calculate);

            //запускаем потоки
            th.Start();
            th1.Start();
            th2.Start();
            th3.Start();


            //соединяем потоки с основным потоком
            th.Join();
            th1.Join();
            th2.Join();
            th3.Join();

            //считаем сумму всех калькуляторов
            l.Content = s.result + " " + s1.result + " " + s2.result + " " + s3.result;
            res = s.result + s1.result + s2.result + s3.result;
            label.Content = res;
        }
    }

    public class sumTask
    {

        // в конструкторе инициализируем диапазон значений from , to
        public sumTask(long f, long t)
        {
            from = f;
            to = t;
        }
        public readonly long from, to;
        public long result { get; private set; }

        //считаем сумму всех чисел в заданном в конструкторе диапазоне
        public void Calculate()
        {
            for (long i = from; i <= to; i++)
            {
                result += i;
            }
        }
    }

}
