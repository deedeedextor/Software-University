using System;
using System.IO;

namespace _5.SliceFileL
{
    class Program
    {
        static void Main(string[] args)
        {
            int partsOfFile = 4;

            using (var reader = new FileStream("sliceMe.txt", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)reader.Length / partsOfFile);

                for (int i = 1; i <= partsOfFile; i++)
                {
                    var currentFileName = $"Part-{i}.txt";
                    var currentPieceSize = 0;

                    using (var writer = new FileStream($"{currentFileName}", FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while ((reader.Read(buffer, 0, buffer.Length)) == buffer.Length)
                        {
                            currentPieceSize += buffer.Length;
                            writer.Write(buffer, 0, buffer.Length);

                            if (currentPieceSize >= partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
