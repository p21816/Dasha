using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWpf
{
    class Model
    {
        public ObservableCollection<Car> cars = new ObservableCollection<Car>();

        public bool IsValid(Car obj)
        {
            foreach(var c in cars)
            {
                if ((c.CarName == obj.CarName) && (c.Mark == obj.Mark) && (c.Price == obj.Price)) return false;
            }
            return true;
        }

    }
}
