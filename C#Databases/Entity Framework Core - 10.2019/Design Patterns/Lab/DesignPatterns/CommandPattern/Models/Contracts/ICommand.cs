using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Models.Contracts
{
    public interface ICommand
    {
        void ExecuteAction();
    }
}
