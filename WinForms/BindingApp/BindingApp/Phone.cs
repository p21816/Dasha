using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media;

namespace BindingApp
{
    class Phone : INotifyPropertyChanged
    {

        private double rate = 1.2;
        private void thread()
        {

            Thread.Sleep(5000);
            rate = 2.3;
            OnPropertyChanged("Price");
            
            MediaPlayer pl = new MediaPlayer();
            pl.Open(new Uri("file:///c:/x.mp3"));
            pl.Play();
            Thread.Sleep(2000);
            pl.Stop();
        }
        public Phone()
        {
            // thread();
            Thread th = new Thread(thread);
            th.Start();

        }
        private string title;
        private double volume;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                OnPropertyChanged("Volume");
                OnPropertyChanged("Price");
            }
        }
        public double Price
        {
            get { return rate*volume; }
          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}