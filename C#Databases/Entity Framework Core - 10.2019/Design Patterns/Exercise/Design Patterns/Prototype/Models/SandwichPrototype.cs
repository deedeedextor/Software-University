using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype Clone();
    }
}
