using AnimalCentre.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.IO
{
    public class ConsoleDataReader : IDataReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
