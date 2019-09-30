using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Commands.Contracts
{
    public interface ICommandParser
    {
        ICommand Parse(string input);
    }
}
