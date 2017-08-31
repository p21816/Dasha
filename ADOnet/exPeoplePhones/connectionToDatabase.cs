using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using System.Windows;


namespace exPeoplePhones
{
    class connectionToDatabase
    {
        string connectionString = @"Data Source=a3-prepod\A203;Initial Catalog=Phonebook;Integrated Security=True";

        public ObservableCollection<PeoplePhones> getInfoFromDataBase()
        {
            ObservableCollection<PeoplePhones> PhonesInfo = new ObservableCollection<PeoplePhones>();
            string queryString = "SELECT People.Id, Firstname, Lastname, PersonalNumber from dbo.People left join dbo.Phones on People.Id = Phones.people_id where People.lastname LIKE 'A%' AND Phones.phone IS NULL";
            string providerName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;


            using (connection)
            {
                try
                {
                    connection.Open();
                    DbCommand command = connection.CreateCommand();
                    command.CommandText = queryString;
                    command.CommandType = CommandType.Text;


                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PeoplePhones h = new PeoplePhones();
                        h.Id = Convert.ToInt32(reader[0]);
                        h.FirstName = reader[1].ToString();
                        h.LastName = reader[2].ToString();
                        h.PersonalNumber = reader[3].ToString();
                        PhonesInfo.Add(h);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Console.ReadLine();
            }
            return PhonesInfo;
        }
    }


}
 //select a.Id, a.Firstname, a.Lastname, a.PersonalNumber from Phones b
 //      join People a on (b.people_id = a.Id) group by a.CathegoryName order by FrequencyQuery desc;