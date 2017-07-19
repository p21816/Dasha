using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyConnection
{
    public class PeoplesPhones:INotifyPropertyChanged
    {
        public PeoplesPhones(SqlDataReader reader){
            id = reader.GetInt32(0);
            FName = reader.GetString(1);
            LName = reader.GetString(2);
            Phone = reader.GetString(3);

        }
        public readonly int id;

        public int Id1
        {
            get { return id; }
            //set { id = value; }
        }
        private string fname;

        public string FName
        {
            get { return fname; }
            set { fname = value;
             OnPropertyChanged("FName");}
        }

        private string lname;

        public string LName
        {
            get { return lname; }
            set { lname = value;
            OnPropertyChanged("LName");
            }
        }


        //private int idp;

        //public readonly int Idp1
        //{
        //    get { return idp; }
        //    set { idp = value; }
        //}
        //private int peopleid;

        //public readonly int PeopleId
        //{
        //    get { return peopleid; }
        //    set { peopleid = value; }
        //}

        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
