using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelsRotateDll
{
    public interface DashkasPlugin
    {
        void Transform(uint[,] input, uint[,] output);
        string GetButtonName();

         int imgSize{get; set;}
         double angle { get; set; }
      }
}
