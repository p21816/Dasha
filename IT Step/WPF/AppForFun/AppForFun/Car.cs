using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamWpf
{
    public class Car
    {
        private string mark;
        public string Mark
        {
            get { return mark; }
            set { mark = value;
            OnPropertyChanged("Mark");
            }
        }
        private string carName;
        public string CarName
        {
            get { return carName; }
            set { carName = value;
            OnPropertyChanged("CarName");
            }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { price = value;
            OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public Car() { }
        public Car(string carMark, string carName, int price)
        {
            this.Mark = carMark;
            this.CarName = carName;
            this.price = price;
        }

        public override string ToString()
        {
            return this.mark + " " + this.carName + " " + this.price;
        }
    }
}
