using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace datdagridWPF_connected_to_database_through_ADOnet
{
        public class Model
        {
            public ObservableCollection<HotelDescription> HotelsData = new ObservableCollection<HotelDescription>();
        }

    class connectionToDatabase
    {
            string connectionString = "Server=(localdb)\\Projects;Integrated Security=true;Initial Catalog=exammm;";
            string queryString = "SELECT Id, HotelName, idCountry from dbo.Hotels ";
            int paramValue = 1;

            public ObservableCollection<HotelDescription> getInfoFromDataBase()
            {
                ObservableCollection<HotelDescription> HotelsInfo = new ObservableCollection<HotelDescription>();

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@pricePoint", paramValue);

                    // Open the connection in a try/catch block. 
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            HotelDescription h = new HotelDescription();
                            h.Id1 = Convert.ToInt32(reader[0]);
                            h.Name = reader[1].ToString();
                            h.IdCountry = Convert.ToInt32(reader[2]);
                            HotelsInfo.Add(h);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                }
                return HotelsInfo;
            }
    }
}
