using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            double lengthRoomMeters = double.Parse(Console.ReadLine());
            double widthRoomMeters = double.Parse(Console.ReadLine());
            double lengthRoomCentimeters = lengthRoomMeters * 100;
            double widthRoomCentimeters = widthRoomMeters * 100;

            int lengthDesk = 120;
            int widthDesk = 70;
            int widthCorridor = 100;

            double rows = Math.Truncate(lengthRoomCentimeters / lengthDesk);
            double realWidthRoomCentimeters = widthRoomCentimeters - widthCorridor;
            double desksPerRow = Math.Truncate(realWidthRoomCentimeters / widthDesk);

            double numDesks = rows * desksPerRow - 3;
            Console.WriteLine(numDesks);
        }
    }
}
