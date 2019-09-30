using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Commands.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        string[] Arguments { get; }
    }
}
