using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaphoreWPF
{
    class Workers
    {
        static int number = 0;
        int serial = number++;
        public void WorkingThread()
        {
            for (int i = 0; i < 10000; i++)
            {
                Logger.Log(String.Format("Worker {0} said {1}", serial, i));
            }
        }
    }
}
