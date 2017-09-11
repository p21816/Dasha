using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDll
{
    public class CoolCalculator : DllWpfApplication.IPlugin
    {

        public string GetButtonName()
        {
            return "Get zero";
        }

        public int Calculate()
        {
            return 0;
        }
    }
}
