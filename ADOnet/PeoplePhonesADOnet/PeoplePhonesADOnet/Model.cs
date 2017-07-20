using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePhonesADOnet
{
    public class Model
    {
        public ObservableCollection<Human> PeopleData { get; set; }
        private Model() {
            PeopleData = new ObservableCollection<Human>();
        }

        public Human GetHumanById(int id)
        {
            for(int i = 0 ; i < PeopleData.Count; i ++)
            {
                if (PeopleData[i].Id ==  id) return PeopleData[i];
            }
            return null;
        }


        private static Model instance = null;
        public static Model Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Model();
                }
                return instance;
            }
        }
    }
}
