using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());

            double volumeSpacecraft = width * length * height;
            double volumeRoom = (averageHeight + 0.40) * 2 * 2;
            double numPeople = Math.Floor(volumeSpacecraft / volumeRoom);
            
            if (numPeople >= 3 && numPeople <= 10)
            {
                Console.WriteLine($"The spacecraft holds {numPeople} astronauts.");
            }
            else if (numPeople < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (numPeople > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
