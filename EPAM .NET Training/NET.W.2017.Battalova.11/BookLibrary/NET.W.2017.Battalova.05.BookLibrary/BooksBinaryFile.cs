using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public class BooksBinaryFile: IBookStorage
    {
      private List<Book> bookCollection = new List<Book>();
      string fileName = ReadSetting("fileName");

        /// <summary>
        /// read boks from a storage
        /// </summary>
        /// <returns>a book collection</returns>
      public List<Book> ReadBooks()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            Book b = new Book(reader.ReadString(),
                                              reader.ReadString(),
                                              reader.ReadString(),
                                              reader.ReadInt32(),
                                              reader.ReadInt32(),
                                              reader.ReadDecimal()
                                              );
                            bookCollection.Add(b);
                        }
                    }
                }
            }
                catch(Exception e)
                {
                 Program.logger.Info("Unhandled exception:");
                 Program.logger.Error(e.StackTrace);
                }
 
            return bookCollection;
        }


        /// <summary>
        /// write books to a storage
        /// </summary>
        /// <param name="li">a book collection to write</param>
      public void WriteBooks(List<Book> li)
       {
               using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
               {
                   foreach (Book b in li)
                   {
                       writer.Write(b.ISBNProperty);
                       writer.Write(b.Name);
                       writer.Write(b.Publisher);
                       writer.Write(b.Year);
                       writer.Write(b.PagesNumber);
                       writer.Write(b.Price);
                   }
               }
       }


        /// <summary>
        /// read settings from an app config
        /// </summary>
        /// <param name="key">name of a setting</param>
        /// <returns>a value of a setting from app config</returns>

       private static string ReadSetting(string key)
       {
           string result = string.Empty;
           try
           {
               var appSettings = ConfigurationManager.AppSettings;
               result = appSettings[key] ?? "Not Found";
           }
           catch (ConfigurationErrorsException e)
           {
               Program.logger.Info("Unhandled exception:");
               Program.logger.Error(e.StackTrace);
           }
           return result;
       }


    }
}
