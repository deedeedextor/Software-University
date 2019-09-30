using MortalEngines.IO.Contracts;

namespace MortalEngines.IO
{
    public class Writer : IWriter
    {
        public void Write(string content)
        {
            System.Console.WriteLine(content);
        }
    }
}
