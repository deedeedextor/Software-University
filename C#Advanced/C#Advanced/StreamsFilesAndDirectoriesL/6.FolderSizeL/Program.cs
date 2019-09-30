using System;
using System.IO;

namespace _6.FolderSizeL
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("../../../TestFolder");
            double sum = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;
            File.WriteAllText("output.txt", sum.ToString());
            Console.WriteLine(sum.ToString());
        }
    }
}
