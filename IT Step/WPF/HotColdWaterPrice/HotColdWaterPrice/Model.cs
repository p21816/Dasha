using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace HotColdWaterPrice
{
    class Model : INotifyPropertyChanged
    {
        private int numberOfPeople;
        private double VolumePerPerson;
        private double PriceLower;
        private double PriceHigher;
        private double ColdVolume;
        private double HotVolume;
        private double TotalVolume;

        public double TotalPrice1
        {
            get {
                if (TotalVol() <= VolumePerPerson)
                {
                    return TotalVol() * PriceLower;
                }
                else
                {
                    return TotalVol() * PriceHigher;
                }
            }
        }
        public Model() { }

        public Model(int numberOfPeople, double VolumePerPerson, double PriceLower, double PriceHigher, double ColdVolume, double HotVolume)
        {
            this.numberOfPeople = numberOfPeople;
            this.VolumePerPerson = VolumePerPerson;
            this.PriceLower = PriceLower;
            this.PriceHigher = PriceHigher;
            this.ColdVolume = ColdVolume;
            this.HotVolume = HotVolume;
        }
        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            set { 
                numberOfPeople = value;
                OnPropertyChanged("NumberOfPeople");
                OnPropertyChanged("TotalPrice1");
            }
        }

        public double VolumePerPerson1
        {
            get { return VolumePerPerson; }
            set { VolumePerPerson = value;
            OnPropertyChanged("VolumePerPerson1");
            OnPropertyChanged("TotalPrice1");
            }
        }

        public double PriceLower1
        {
            get { return PriceLower; }
            set { PriceLower = value;
            OnPropertyChanged("PriceLower1");
            OnPropertyChanged("TotalPrice1");
            }
        }

        public double PriceHigher1
        {
            get { return PriceHigher; }
            set { PriceHigher = value;
            OnPropertyChanged("PriceHigher1");
            OnPropertyChanged("TotalPrice1");
            }
        }

        public double ColdVolume1
        {
            get { return ColdVolume; }
            set { ColdVolume = value;
            OnPropertyChanged("ColdVolume1");
            OnPropertyChanged("TotalPrice1");
            }
        }

        public double HotVolume1
        {
            get { return HotVolume; }
            set { HotVolume = value;
            OnPropertyChanged("HotVolume1");
            OnPropertyChanged("TotalPrice1");
            }
        }

        public double TotalVol()
        {
            TotalVolume = HotVolume + ColdVolume;
            return TotalVolume;
        }

        //public double countPrice()
        //{
        //    if(TotalVol() <= VolumePerPerson)
        //    {
        //        TotalPrice = TotalVol() * PriceLower;
        //    }
        //    else
        //    {
        //        TotalPrice = TotalVol() * PriceHigher;
        //    }
        //    return TotalPrice;
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
