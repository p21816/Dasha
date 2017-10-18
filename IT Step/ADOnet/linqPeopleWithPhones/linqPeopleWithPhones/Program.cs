using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqPeopleWithPhones
{
    class Program
    {
        [Table(Name = "People")]
        public class User
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Id { get; set; }

            [Column(Name = "Firstname")]
            public string FirstName { get; set; }

            [Column(Name = "Lastname")]
            public string LastName { get; set; }

            [Column(Name = "PersonalNumber")]
            public string PersonalNumber { get; set; }

            [Column(Name = "MoodId")]
            public int MoodId { get; set; }
        }

        [Table(Name = "Phones")]
        public class Phone
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Id { get; set; }

            [Column(Name = "people_id")]
            public int people_id { get; set; }

            [Column(Name = "phone")]
            public string phone { get; set; }
        }

        static string connectionString = "Server=(localdb)\\Projects;Integrated Security=true;Initial Catalog=PeoplePhones;";
        static void Main(string[] args)
        {
            DataContext db = new DataContext(connectionString);
            Table<User> users = db.GetTable<User>();
            Table<Phone> phones = db.GetTable<Phone>();
            var peopleWithPhones = from u in users join p in phones on u.Id equals p.people_id
                                   group p by new { u.Id, u.LastName } into g
                                   select new { lala = g.Key.Id, Lastname = g.Key.LastName, gi = g };



            foreach (var u in peopleWithPhones)
            {
                Console.WriteLine(u.Lastname);
                foreach(var f in u.gi)
                {
                    Console.WriteLine(f.phone);
                }
            }

            //foreach (var p in people)
            //{
            //    Console.WriteLine(p.LastName);
            //}
        }

    }
}
