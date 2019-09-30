﻿namespace MilitaryElite.Soldiers.Privates
{
    using MilitaryElite.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
        }
    }
}
