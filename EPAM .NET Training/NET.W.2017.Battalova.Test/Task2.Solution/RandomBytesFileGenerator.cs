using System;
using System.IO;
using Task2.Solution;

namespace Task_2
{
    public class RandomBytesFileGenerator : AbstractFileGenerator
    {
        public override string WorkingDirectory 
        {
            get
            {
                return "Files with random bytes";
            }
        }

        public override string FileExtension 
        {
            get
            {
                return ".bytes";
            }
        }

        public override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }

    }
}