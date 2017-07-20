using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePhonesADOnet
{
    public class Human : INotifyPropertyChanged
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string firstname;
        public string FirstName
        {
            get { return firstname; }
            set {
                    firstname = value;
                    OnPropertyChanged("FirstName");
                 }
        }

    

        string lastname;
        public string LastName
        {
            get { return lastname; }
            set {
                    lastname = value;
                    OnPropertyChanged("LastName");
                }
        }

        string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Human(int a, string b , string c, string d)
        {
            Id = a;
            FirstName = b;
            LastName = c;
            Phone = d;
        }

         public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
