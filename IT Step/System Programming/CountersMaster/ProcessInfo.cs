using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CountersMaster
{
    class ProcessInfo:INotifyPropertyChanged
    {
        static readonly ProcessPriorityClass[] priorities = new ProcessPriorityClass[] {
            ProcessPriorityClass.Idle,
            ProcessPriorityClass.BelowNormal,
            ProcessPriorityClass.Normal,
            ProcessPriorityClass.AboveNormal,
            ProcessPriorityClass.High,
            ProcessPriorityClass.RealTime
        };

        private int priority=2;
        public int Priority
        {
            get
            {
                return priority;
            }
            set
            {
                if ((value < 0) || (value >= priorities.Length))
                {
                    throw new ArgumentOutOfRangeException("Ooops");
                }
                if (value == priority)
                {
                    return;
                }
                process.PriorityClass = priorities[value];
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public ProcessInfo()
        {
            process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = @"..\..\..\Counters\bin\Debug\Counters.exe";
            process.Exited += process_Exited;
            process.Start();
        }

        void process_Exited(object sender, EventArgs e)
        {
            MainWindow.pc.Remove(this);
        }


        private Process process;
        public void Kill()
        {
            process.Kill();
        }
        public int PID { get { return process.Id; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
