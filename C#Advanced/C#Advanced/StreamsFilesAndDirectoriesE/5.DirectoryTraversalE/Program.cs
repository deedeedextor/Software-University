using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _6.FullDirectoryTraversalE
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path);

            var extentionFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                if (!extentionFileInfo.ContainsKey(info.Extension))
                {
                    extentionFileInfo[info.Extension] = new List<FileInfo>();
                }

                extentionFileInfo[info.Extension].Add(info);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.txt";

            using (var writer = new StreamWriter(desktopPath))
            {
                foreach (var kvp in extentionFileInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    string extension = kvp.Key;
                    List<FileInfo> nameAndSize = kvp.Value;

                    writer.WriteLine(extension);

                    foreach (var fileInfo in nameAndSize.OrderByDescending(x => x.Length))
                    {
                        string name = fileInfo.Name;
                        double size = fileInfo.Length / 1024;

                        writer.WriteLine($"--{name} - {size:F3}kb");
                    }
                }
            }
        }
    }
}

