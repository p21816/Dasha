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
   
    class ConnectionToDatabase
    {
        List<int> ids = new List<int>();

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
                        Human h = new Human(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                        h.PropertyChanged += h_PropertyChanged;
                        Model.Instance.PeopleData.Add(h);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return Model.Instance.PeopleData;
        }

        void h_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            int i = ((Human)sender).Id;
            ids.Add(i);
        }


        public void setInfoToDataBase()  //запись данных в базу данных
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach(int i in ids)
                    {
                        string queryString =
                              "UPDATE dbo.People SET Firstname = @hName , Lastname = @hLastName WHERE People.Id = @editedId";
                        string paramValue1 = Model.Instance.GetHumanById(i).FirstName;
                        string paramValue2 = Model.Instance.GetHumanById(i).LastName;
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@hName", paramValue1);
                        command.Parameters.AddWithValue("@hLastName", paramValue2);
                        command.Parameters.AddWithValue("@editedId", i);
                        int numberOfUpdations = command.ExecuteNonQuery();
                    }

                    //for (int i = 0; i < Model.Instance.PeopleData.Count; i++)
                    //{
                    //    string queryString =
                    //        string.Format("UPDATE dbo.People SET Firstname = @hName , Lastname = @hLastName WHERE People.Id = '{0}'", Model.Instance.PeopleData[i].Id);
                    //    string paramValue1 = Model.Instance.PeopleData[i].FirstName;
                    //    string paramValue2 = Model.Instance.PeopleData[i].LastName;
                    //    SqlCommand command = new SqlCommand(queryString, connection);
                    //    command.Parameters.AddWithValue("@hName", paramValue1);
                    //    command.Parameters.AddWithValue("@hLastName", paramValue2);
                    //    int numberOfUpdations = command.ExecuteNonQuery();
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
