using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface ILinkedList
    {
        void AddFirst(IListItem item); //добавить элемент в начало
        void AddLast(IListItem item); //добавить элемент в конец
        void Insert(IListItem item, int index); //вставить элемент по индексу или в начало, если список пуст
        bool IsEmpty(); //проверка пустой ли список
        IListItem GetFirstItem(); //получить первый "корневой" элемент списка
        IEnumerable<IListItem> GetAll(); //получить все элементы, кроме корневого
        void Clear(); //очистить список
        void Reverse(); //отсортировать список в обратном порядке и перестроить связи
    }
}
