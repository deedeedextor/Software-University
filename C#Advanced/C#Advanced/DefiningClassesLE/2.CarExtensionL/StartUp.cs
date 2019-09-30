﻿namespace CarManufacturer
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;

            try
            {
                car.Drive(2000);
            }
            catch (Exception exception)
            {
                var error = exception.Message;
            }

            Console.WriteLine(car.WhoAmI());
        }
    }
}
