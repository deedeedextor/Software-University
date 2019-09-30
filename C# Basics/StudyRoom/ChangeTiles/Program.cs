using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthGround = int.Parse(Console.ReadLine());
            double widthTile = double.Parse(Console.ReadLine());
            double lengthTile = double.Parse(Console.ReadLine());
            int widthBench = int.Parse(Console.ReadLine());
            int lengthBench = int.Parse(Console.ReadLine());

            int areaGroung = lengthGround * lengthGround;
            int areaBench = widthBench * lengthBench;
            int areaCover = areaGroung - areaBench;
            double areaTile = widthTile * lengthTile;
            double numTiles = areaCover / areaTile;
            double time = numTiles * 0.2;

            Console.WriteLine(numTiles);
            Console.WriteLine(time);
        }
    }
}
