namespace Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface Icar
    {
        string Model { get; }

        string Color { get; }

        string Start();

        string Stop();
    }
}
