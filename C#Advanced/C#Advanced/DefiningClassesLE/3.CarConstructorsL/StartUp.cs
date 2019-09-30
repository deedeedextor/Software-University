using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdcar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            List<Car> cars = new List<Car>();

            cars.Add(firstCar);
            cars.Add(secondCar);
            cars.Add(thirdcar);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Make}\n{car.Model}\n{car.Year}\n{car.FuelQuantity}\n{car.FuelConsumption}");
            }
        }
    }
}
