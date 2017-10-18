using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllWpfApplication
{
    public interface IPlugin
    {
        string GetButtonName();
        int Calculate();
    }
}
