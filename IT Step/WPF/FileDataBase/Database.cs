using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileDataBase
{
    public class Database
    {
        public class Record
        {
            private int id;
            public int ID
            {
                get { return id; }
                set { id = value; }
            }


            private string lastName;
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }


            private string firstName;
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value;
                OnPropertyChanged("FirstName");
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName]string prop = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            public static  bool operator == (Record a, Record b)
            {
                if (a.firstName == b.firstName) return true;
                else return false;
            }

            public static  bool operator != (Record a, Record b)
            {
                if (a.firstName == b.firstName) return false;
                else return true;
            }

            public static  bool operator >= (Record a, Record b)
            {
                return (String.Compare(a.firstName,b.firstName) >= 0);
            }
            public static  bool operator <= (Record a, Record b)
            {
                return (String.Compare(a.firstName, b.firstName) <= 0);
            }

        public  override string  ToString()
        {
            return this.id + " " + this.firstName + " " + this.lastName ;
        }

        }

        public readonly static Database Instance = new Database();
        private string pathToDatabase = "../../database.csv";
        private string pathToLineIndexes = "../../LineIndexes.txt";
        public List<int> indexes = new List<int>();
        int index = 0;
        private Database()
        {
            File.Delete(pathToDatabase);
            File.Delete(pathToLineIndexes);
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


            bool hasAdded = false;
            for (int i = 0; i < index; i++)
            {
                var elem = Instance[indexes[i]];
                if(elem >= record)
                {
                    indexes.Insert(i, index);
                    hasAdded=true;
                    break;
                }
            }
            if (!hasAdded)
            {
                indexes.Add(index);
            }
            index++;

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
                reader.Close();

                StreamReader file = new StreamReader(pathToDatabase);
                file.BaseStream.Position = temp; //setting the cursor
                string record = file.ReadLine();
                string[] records = record.Split(',');
                file.Close();

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
