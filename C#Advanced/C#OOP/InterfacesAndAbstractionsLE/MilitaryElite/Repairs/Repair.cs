namespace MilitaryElite.Repairs
{
    using MilitaryElite.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Repair : IRepair
    {
        private string partName;
        private int workHours;

        public Repair(string partName, int workHours)
        {
            this.PartName = partName;
            this.WorkHours = workHours;
        }

        public string PartName { get; private set; }

        public int WorkHours { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.WorkHours}";
        }
    }
}
