using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2;

namespace Task2.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomBytesFileGenerator bytesGenerator = new RandomBytesFileGenerator();
            bytesGenerator.GenerateFiles(2, 50);
            byte [] content = bytesGenerator.GenerateFileContent(30);
            bytesGenerator.WriteBytesToFile("customFile", content);

            RandomCharsFileGenerator charsGenerator = new RandomCharsFileGenerator();
            charsGenerator.GenerateFiles(2, 50);
            byte[] chars = charsGenerator.GenerateFileContent(30);
            charsGenerator.WriteBytesToFile("newFile", chars);
        }
    }
}
