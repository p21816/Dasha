using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._04
{

    /// <summary>
    /// interface for comparison of two strings of a jagged array
    /// </summary>
    public interface IComparer
    {
        int CompareTo(int[] lhs, int[] rhs);
    }
}
