using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePhonesADOnet
{
    public class Human
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
            set { firstname = value; }
        }

        string lastname;
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
