using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //   ListItem l = new ListItem("hello");
            //   ListItem l1 = new ListItem("world");

            // //  string h = l.Value.ToString();
            ////   Console.WriteLine(h);

            //   LinkedList li = new LinkedList();
            //   li.AddFirst(l);
            //   li.AddLast(l1);
            //   li.AddLast(l1);
            //        li.Insert(l, 2);
            // //  li.Reverse();

            //   //    Console.WriteLine(li.ToString());
            //   li.View();
            // //  l1 = (ListItem)li.GetFirstItem();
            ////   Console.WriteLine(l1.Value.ToString());

            ListItem item = new ListItem(1, new ListItem(2, new ListItem(3)));
            ListItem i = new ListItem(1);
            ListItem i1 = new ListItem(2);
            ListItem i2 = new ListItem(3);
            ListItem i3 = new ListItem(4);
            LinkedList li = new LinkedList();
            li.AddFirst(i);
            li.AddFirst(i1);
            li.AddFirst(i2);
            IListItem first;
           // li.AddFirst(item);
          //  li.Insert(i3, 3);
            first = li.GetFirstItem();

           // li.GetAll();
        }
    }


    //прямой связанный список
    public class LinkedList : ILinkedList
    {
        private ListItem head;
        private ListItem tail;
        private int count = 0;

        //добавить элемент в начало
        public void AddFirst(IListItem item)
        {
            if(item.Prev() != null)
            {
                Console.WriteLine("Hello");
            }
            else if (head == null)
            {
                ListItem temp = new ListItem(item);
                head = temp;
                tail = temp;
                count++;
            }
            else
            {
                ListItem temp = new ListItem(item);
                temp.Next1 = head;
                head.Prev1 = temp;
                head = temp;
                count++;
            }
        }

        //добавить элемент в конец
        public void AddLast(IListItem item)
        {
            if (head == null)
            {
                AddFirst(item);
            }
            else
            {
                ListItem temp = new ListItem(item);
                temp.Prev1 = tail;
                tail.Next1 = temp;
                tail = temp;
                count++;
            }
        }

        //вставить элемент перед элементом с указанным индексом
        //если элемента нет - вставить в конец
        public void Insert(IListItem item, int index)
        {
            if (index > count || index < 0)
            {
                AddLast(item);
            }
            else
            {
                IListItem current;
                IListItem preCurrent;
                current = head;
                preCurrent = head;
                int i = 1;
                while (i < index)
                {
                    preCurrent = current;
                    current = current.Next();
                    i++;
                }

                ListItem temp = new ListItem(item);
                temp.Next1 = current;
                temp.Prev1 = preCurrent;
                count++;
            }
        }

        //проверка есть ли эелементы в списке
        public bool IsEmpty()
        {
            if (head == null) return true;
            return false;
        }

        //вернуть первый эелемент в списке
        public IListItem GetFirstItem()
        {
            return head;
        }

        //вернуть все элементы списка, кроме первого
        public IEnumerable<IListItem> GetAll()
        {
            List<IListItem> li = new List<IListItem>();
            int i = 1;
            IListItem cur;
            cur = head.Next1;
            while(i < count)
            {
                li.Add(cur);
                cur = cur.Next();
                i++;
            }
            return li;
        }

        //очистить список
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        //сортировка списка в обратном порядке
        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }







        //прямой связанный список
        //public class LinkedList : ILinkedList
        //{
        //    private ListItem head;
        //    private ListItem tail;
        //    private ListItem current;
        //    private int count = 0;
        //    //добавить элемент в начало


        //    public void View()
        //    {
        //        if (head == null) Console.WriteLine("no elements");
        //        else if (head == tail) Console.WriteLine(head.Value.ToString() + " one element");
        //        else
        //        {
        //            int i = 0;
        //            current = head;
        //            while (i < count)
        //            {
        //                Console.WriteLine(current.Value.ToString());
        //                current = current.Next1;
        //                i++;
        //            }
        //        }
        //    }


        //    //вставить элемент перед элементом с указанным индексом
        //    //если элемента нет - вставить в конец
        //    public void Insert(IListItem item, int index)
        //    {
        //        if(index == 0 || index == 1)
        //        {
        //            AddFirst(item);
        //        }
        //        if(index >= count)
        //        {
        //            AddLast(item);
        //        }
        //        else
        //        {
        //            int i = 0;
        //            current = head;
        //            while (i < index)
        //            {
        //                current = current.Next1;
        //                i++;
        //            }

        //            ListItem temp = new ListItem(item);

        //            temp.Next1 = current.Next1;
        //            temp.Prev1 = current;
        //            current.Next1.Prev1 = temp;
        //            current.Next1 = temp;
        //        }
        //    }

        //    //проверка есть ли эелементы в списке
        //    public bool IsEmpty()
        //    {
        //        if (head == null) return true;
        //        return false;
        //    }

        //    //вернуть первый эелемент в списке
        //    public IListItem GetFirstItem()
        //    {
        //        return head;
        //    }

        //    //вернуть все элементы списка, кроме первого
        //    public IEnumerable<IListItem> GetAll()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    //очистить список
        //    public void Clear()
        //    {
        //        head = null;
        //        tail = null;
        //        count = 0;
        //    }

        //    //сортировка списка в обратном порядке
        //    public void Reverse()
        //    {
        //        int i = 0;
        //        current = head;
        //        ListItem temp = new ListItem("temp_obj");

        //        while (i < count)
        //        {
        //            current = current.Next1;
        //            temp = current.Prev1;
        //            current.Prev1 = current.Next1;
        //            current.Next1 = temp;
        //            i++;
        //        }
        //    }
        //}










        //элемент связанного списка
        public class ListItem : IListItem
        {
            public ListItem(object obj, IListItem prev = null)
            {
                //логика инициализации
                value = obj;
                Prev1 = prev;
                if (prev != null)
                {
                    ((ListItem)Prev1).Next1 = this;
                }
            }

            //предыдущий связанный элемент списка
            public IListItem Prev()
            {
                return Prev1;
            }

            //следующий связанный элемент списка
            public IListItem Next()
            {
                return Next1;
            }

            private object value;
            //хранимое значение
            public object Value
            {
                get { return value; }
            }

            public IListItem Prev1
            {
                get { return prev; }
                set { prev = value; }
            }
            public IListItem Next1
            {
                get { return next; }
                set { next = value; }
            }

            private IListItem prev;
            private IListItem next;
        }
    }

