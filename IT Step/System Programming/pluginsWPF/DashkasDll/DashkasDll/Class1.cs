using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashkasDll
{
    public class Class1 : DllWpfApplication.IPlugin
    {
        public string GetButtonName()
        {
            return "Get 42";
        }

        public int Calculate()
        {
            return 42;
        }
    }
}
