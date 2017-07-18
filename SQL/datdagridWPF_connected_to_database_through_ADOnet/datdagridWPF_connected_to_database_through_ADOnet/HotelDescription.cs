using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datdagridWPF_connected_to_database_through_ADOnet
{
    public class HotelDescription
    {
        private int id;

        public int Id1
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int idCountry;
        public int IdCountry
        {
            get { return idCountry; }
            set { idCountry = value; }
        }

    }
}
