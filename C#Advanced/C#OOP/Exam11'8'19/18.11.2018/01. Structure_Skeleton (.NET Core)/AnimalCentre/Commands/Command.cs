using AnimalCentre.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Commands
{
    public class Command : ICommand
    {
        public Command(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; private set; }

        public string[] Arguments { get; private set; }
    }
}
