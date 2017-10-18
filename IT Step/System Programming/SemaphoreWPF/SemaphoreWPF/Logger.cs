using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace SemaphoreWPF
{
    class Logger
    {
        static Semaphore s = new Semaphore(2,2);
        static Mutex m = new Mutex();
        static Mutex m1 = new Mutex();
        static Random r = new Random();
        static int i = 0;
        static public void Log(string text)
        {
            int rand = r.Next(0, 1);
            if (rand == 1) i = 0;
            else if (rand == 0) i = 1;

            s.WaitOne();
            if (m.WaitOne(new TimeSpan(0,0,0,0,0))) // если она свободна, то сюда зайдет, а если нет, то сразу на else , 00000 -  не будет ждать нисколько времени пока оно освободиться, а сразу на else уйдет
            {
                loggers[rand].Write(text);
                m.ReleaseMutex();
            }
           else 
            {
                 m1.WaitOne();
                 loggers[i].Write(text);
                 m1.ReleaseMutex();
            }
            s.Release();
        }

        static List<Logger> loggers = new List<Logger>()
        {
            new Logger(@"d:\log1.txt"),
            new Logger(@"d:\log2.txt")
        };
        private StreamWriter sw;
        private Logger(string filename)
        {
            sw = File.AppendText(filename);
        }
        private void Write(string text)
        {
            sw.WriteLine(text);
        }

    }
}
