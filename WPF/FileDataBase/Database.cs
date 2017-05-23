using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDataBase
{
    class Database
    {
        public class Record
        {
            public int ID;
            public string LastName;
            public string FirstName;
        }

        public readonly static Database Instance = new Database();
        private string pathToDatabase = "../../database.txt";
        private string pathToLineIndexes = "../../LineIndexes.txt";
        private Database()
        {
                
        }
        public void Add(Record record)
        {
            FileStream file = new FileStream(pathToDatabase , FileMode.Open);
            int cursor = Convert.ToInt32(file.Position);
            byte [] arr = System.Text.Encoding.Default.GetBytes(record.ID.ToString() + "," + record.FirstName.ToString() + "," + record.LastName.ToString());
            file.Write(arr , cursor , arr.Length);
            file.Close();

            // 1. открыть файл, перемотать в конец
            // 2. узнать позицию курсора
            // 3. записать запись
            // 4. закрыть
            // 5. записать в другой файл позицию курсора
            long pos = 100;
            File.AppendAllText("index.dat", pos.ToString() + "\n");
        }

        public Record this[int LineNumber]
        {
            get {
                // открыть файл с построчным индексом
                // найти запись номер LineNumber, прочитали в offset
                // открыли основной файл, перемотали на offest
                // прочитали запись 
                return new Record();
            }
            
        }
    }
}
