using AnimalCentre.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Commands
{
    public class CommandParser : ICommandParser
    {
        public ICommand Parse(string input)
        {
            var inputParts = input.Split();
            var name = inputParts[0];
            var arguments = inputParts.Skip(1).ToArray();

            return new Command(name, arguments);
        }
    }
}
