namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Shape //80-100
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return "Shape";
        }
    }
}
