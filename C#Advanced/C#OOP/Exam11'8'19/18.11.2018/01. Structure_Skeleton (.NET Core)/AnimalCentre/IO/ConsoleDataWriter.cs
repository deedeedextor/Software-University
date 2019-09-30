using AnimalCentre.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.IO
{
    public class ConsoleDataWriter : IDataWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
