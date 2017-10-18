using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace MyConnection
{
    public class Model


    {

        public Model()
        {
            getInfoFromDataBase();
        }

        private ObservableCollection<PeoplesPhones> PFData = new ObservableCollection<PeoplesPhones>();

        public ObservableCollection<PeoplesPhones> PFData1
        {
            get { return PFData; }
            set { PFData = value; }
        }
       
        string connectionString = "Server=(localdb)\\Projects;Integrated Security=true;Initial Catalog=PeoplePhones;";
        string queryString = "SELECT a.Id as PeopleID, a.Firstname , a.Lastname, b.phone from dbo.Phones b " +
            "left join People a on b.people_id = a.Id";
        int paramValue = 1;

        public void getInfoFromDataBase()
        {

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
               // command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PeoplesPhones h = new PeoplesPhones (reader);
                        PFData.Add(h);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}