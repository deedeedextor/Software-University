using Solid.Loggers.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Solid.Loggers
{
    public class LogFile : ILogFile
    {
        private const string Path = @"..\..\..\log.txt";

        public LogFile()
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            fs.Close();
        }

        public int Size
        {
            get
            {
                using (var stream = new StreamReader(Path))
                {
                    return stream.ReadToEnd().ToCharArray()
                        .Where(Char.IsLetter)
                        .Sum(c => c);
                }
            }
        }

        public void Write(string content)
        {
            using (var stream = new StreamWriter(Path, true))
            {
                stream.WriteLine(content);
            }
        }
    }
}
