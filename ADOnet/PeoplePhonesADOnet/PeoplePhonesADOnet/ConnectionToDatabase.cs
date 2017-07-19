using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PeoplePhonesADOnet
{
    public static class Model
    {
        static public ObservableCollection<Human> PeopleData = new ObservableCollection<Human>();
    }
    class ConnectionToDatabase
    {
        string connectionString = "Server=(localdb)\\Projects;Integrated Security=true;Initial Catalog=PeoplePhones;";
        public ObservableCollection<Human> getInfoFromDataBase() //чтение данных из базы
        {
            string queryString = "SELECT People.Id, Firstname, Lastname , MAX(phone) from dbo.People LEFT JOIN dbo.Phones ON People.Id = Phones.people_id GROUP BY people.Id, Firstname, Lastname ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Human h = new Human();
                        h.Id = Convert.ToInt32(reader[0]);
                        h.FirstName = reader[1].ToString();
                        h.LastName = reader[2].ToString();
                        h.Phone = reader[3].ToString();
                        Model.PeopleData.Add(h);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return Model.PeopleData;
        }


        public void setInfoToDataBase()  //запись данных в базу данных
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    for (int i = 0; i < Model.PeopleData.Count; i++)
                    {
                        string queryString =
                            string.Format("UPDATE dbo.People SET Firstname = @hName , Lastname = @hLastName WHERE People.Id = '{0}'", Model.PeopleData[i].Id);
                        string paramValue1 = Model.PeopleData[i].FirstName;
                        string paramValue2 = Model.PeopleData[i].LastName;
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@hName", paramValue1);
                        command.Parameters.AddWithValue("@hLastName", paramValue2);
                        int numberOfUpdations = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
