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

            public static  bool operator == (Record a, Record b)
            {
                if (a.FirstName == b.FirstName) return true;
                else return false;
            }

            public static  bool operator != (Record a, Record b)
            {
                if (a.FirstName == b.FirstName) return false;
                else return true;
            }

            public static  bool operator >= (Record a, Record b)
            {
                if (a.FirstName.CompareTo(b.FirstName) == -1 || a.FirstName == b.FirstName) return true;
                else return false;
            }
            public static  bool operator <= (Record a, Record b)
            {
                if (a.FirstName.CompareTo(b.FirstName) == 1 || a.FirstName == b.FirstName) return true;
                else return false;
            }

        public  override string  ToString()
        {
            return this.ID + " " + this.FirstName + " " + this.LastName ;
        }

        }

        public readonly static Database Instance = new Database();
        private string pathToDatabase = "../../database.csv";
        private string pathToLineIndexes = "../../LineIndexes.txt";
        public List<int> indexes = new List<int>();
        int index = 0;
        private Database()
        {
                
        }
        public void Add(Record record)
        {
            FileStream file = new FileStream(pathToDatabase , FileMode.Append);
            int cursor = Convert.ToInt32(file.Position);
            byte [] arr = System.Text.Encoding.Default.GetBytes(record.ID.ToString() + "," + record.FirstName.ToString() + "," + record.LastName.ToString() + "\r\n");
            file.Write(arr , 0 , arr.Length);
            file.Close();

            BinaryWriter writer = new BinaryWriter(File.Open(pathToLineIndexes, FileMode.Append));
            writer.Write(cursor);
            writer.Close();

            //if (index == 0)
            //{
            //    indexes.Add(index);
            //}
            //for (int i = 0; i < index; i++)
            //{
            //    if (Instance[i] >= Instance[index])
            //    {
            //        indexes.Insert(i, index);
            //        break;
            //    }
            //    else if (i == index)
            //    {
            //        indexes.Add(index);
            //    }
            //}
            //index++;

            // 1. открыть файл, перемотать в конец
            // 2. узнать позицию курсора
            // 3. записать запись
            // 4. закрыть
            // 5. записать в другой файл позицию курсора
        }

        public Record this[int LineNumber]
        {
            //открыть файл с построчным индексом
            //найти запись номер лайнНамбер, прочитали в оффсет
            //открыли основной файл, перемотали на оффсет
            //прочитали запись
            get
            {
                BinaryReader reader = new BinaryReader(File.Open(pathToLineIndexes, FileMode.Open));
                reader.BaseStream.Position = LineNumber * sizeof(int);
                int temp = reader.ReadInt32();

                StreamReader file = new StreamReader(pathToDatabase);
                file.BaseStream.Position = temp; //setting the cursor
                string record = file.ReadLine();
                string[] records = record.Split(',');

                Record obj = new Record();
                obj.ID = Convert.ToInt32(records[0]);
                obj.FirstName = records[1];
                obj.LastName = records[2];
                return obj;
            }
            //set;
        }



    }
}
