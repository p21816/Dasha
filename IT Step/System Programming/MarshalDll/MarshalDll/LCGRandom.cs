using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MarshalDll
{
    class LCGRandom
    {
        [DllImport(@"D:\Max\MarshalDll\Debug\win32dll.dll", EntryPoint = "rand",  CallingConvention=CallingConvention.Cdecl)]
        public static extern int rand();

        [DllImport(@"D:\Max\MarshalDll\Debug\win32dll.dll", EntryPoint = "srand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void srand(int seed);
    }
}
