using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MarshalDll
{
    static class LCGRandomDynamic
    {
        public delegate int RandDelegate();
        public static RandDelegate rand;
       
        public delegate void SrandDelegate(int seed);
        public static SrandDelegate srand;

        static LCGRandomDynamic()
        {
            int hLib = WinAPIDllLoader.LoadLibrary(@"D:\win32dll.dll");
            if (hLib == 0) {
                throw new Exception("Dll not found");
            }
            IntPtr randPtr = WinAPIDllLoader.GetProcAddress(hLib, "rand");
            if (randPtr == null)
            {
                throw new Exception("rand not found in dll");
            }
            rand = (RandDelegate)Marshal.GetDelegateForFunctionPointer(randPtr, typeof(RandDelegate));


            IntPtr srandPtr = WinAPIDllLoader.GetProcAddress(hLib, "srand");
            if (srandPtr == null)
            {
                throw new Exception("srand not found in dll");
            }
            srand = (SrandDelegate)Marshal.GetDelegateForFunctionPointer(srandPtr, typeof(SrandDelegate));
        }
    }
}
