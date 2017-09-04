using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count
{
    class Program
    {
        static long maxCount = 10000000000;
        static void Main(string[] args)
        {
            for (long i = 0; i < maxCount; i++)
            {
                if (i % (maxCount / 1000) == 0)
                {
                    Console.Write("{0}% complete               \r", (i * 100.0) / maxCount);
                }
            }
            Console.WriteLine("Done                            ");
        }
    }
}
