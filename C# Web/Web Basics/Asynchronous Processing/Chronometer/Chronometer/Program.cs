﻿namespace ChronometerDemo
{
    using ChronometerDemo.Models;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();

            string inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "exit")
            {
                switch (inputLine)
                {
                    case "start":
                        {
                            chronometer.Start();
                            break;
                        }
                    case "stop":
                        {
                            chronometer.Stop();
                            break;
                        }
                    case "lap":
                        {
                            Console.WriteLine(chronometer.Lap());
                            break;
                        }
                    case "time":
                        {
                            Console.WriteLine(chronometer.GetTime);
                            break;
                        }
                    case "laps":
                        {
                            Console.WriteLine("Laps: " + (chronometer.Laps.Count == 0 
                                ? "No laps" 
                                : "\r\n" + string.Join("\r\n", chronometer.Laps
                                .Select((lap, index) => $"{index}. {lap}"))));
                            break;
                        }
                    case "reset":
                        {
                            chronometer.Reset();
                            break;
                        }
                }
            }
        }
    }
}
