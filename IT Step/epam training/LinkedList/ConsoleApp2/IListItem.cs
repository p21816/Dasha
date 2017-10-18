using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IListItem
    {
        IListItem Prev(); //предыдущий элемент
        IListItem Next(); //следующий элемент 
        object Value { get; } //значение, хранимое в элементе
    }
}
