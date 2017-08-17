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


namespace datdagridWPF_connected_to_database_through_ADOnet
{
    public class Model
    {
        public ObservableCollection<HotelDescription> HotelsData = new ObservableCollection<HotelDescription>();
    }

    class connectionToDatabase
    {
            string connectionString = "Server=(localdb)\\Projects;Integrated Security=true;Initial Catalog=exammm;";

            public ObservableCollection<HotelDescription> getInfoFromDataBase()
            {
                ObservableCollection<HotelDescription> HotelsInfo = new ObservableCollection<HotelDescription>();
                string queryString = "SELECT Id, HotelName, idCountry from dbo.Hotels ";
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
                        MessageBox.Show(ex.Message);
                    }
                    Console.ReadLine();
                }
                return HotelsInfo;
            }


            public void setInfoToDataBase(ObservableCollection<HotelDescription> HotelsInfo)
            {
                string providerName = "System.Data.SqlClient";
                DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;
                using (connection)
                {
                    try
                    {
                        connection.Open();

                        for (int i = 0; i < HotelsInfo.Count; i++)
                        {
                            string paramValue1 = HotelsInfo[i].Name;
                            int paramValue2 = HotelsInfo[i].IdCountry;
                            string queryString =
                                string.Format("UPDATE dbo.Hotels SET HotelName = paramValue1 , idCountry = paramValue2 WHERE Hotels.Id = '{0}'", HotelsInfo[i].Id1);
                            //int paramValue0 = HotelsInfo[i].Id1;


                            DbCommand command = connection.CreateCommand();
                            command.CommandText = queryString;
                            command.CommandType = CommandType.Text;

                            //command.Parameters.AddWithValue("@idd", paramValue0);

                            int numberOfUpdations = command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                }
            }
    
    }
}
