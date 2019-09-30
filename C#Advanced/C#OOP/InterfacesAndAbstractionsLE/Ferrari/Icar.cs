namespace Ferrari
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface Icar
    {
         string Model { get; }

         string Driver { get; }

        string Brakes();

        string Gas();
    }
}
