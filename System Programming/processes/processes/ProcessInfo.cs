using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace processes
{
    public class ProcessInfo : INotifyPropertyChanged
    {
        Process process = new Process();
        public ProcessInfo()
        {
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = @"D:\LD\WCF\l1\processes\Count\bin\Debug\Count.exe";
            process.Exited += process_Exited;
            process.Start();
        }
        public void process_Exited(object sender, EventArgs e)
        {

        }

        ProcessPriorityClass[] priorities = 
            {
                ProcessPriorityClass.Idle,
                ProcessPriorityClass.BelowNormal,
                ProcessPriorityClass.Normal,
                ProcessPriorityClass.AboveNormal,
                ProcessPriorityClass.High,
                ProcessPriorityClass.RealTime
            };

        private int currentPriority;
        public int CurrentPriority
        {
            get { return currentPriority; }
            set
            {
                if (value < 0 || value > 5) return;
                currentPriority = value;
                process.PriorityClass = priorities[value];
                OnPropertyChanged("CurrentPriority");
            }
        }

        private int pid;
        public int PID
        {
            get { return pid; }
            set
            {
                pid = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        internal void Kill()
        {
            process.Kill();
        }
    }
}
