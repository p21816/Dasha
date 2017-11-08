using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._04
{
    public interface IComparer
    {
        int CompareTo(int[] lhs, int[] rhs);
    }
}
