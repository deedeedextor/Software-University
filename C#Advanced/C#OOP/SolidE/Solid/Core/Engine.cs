using Solid.Core.Contracts;
using System;

namespace Solid.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int appenders = int.Parse(Console.ReadLine());

            for (int i = 1; i <= appenders; i++)
            {
                string[] appenderArgs = Console.ReadLine()
                    .Split();

                this.commandInterpreter.AddAppender(appenderArgs);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] reportArgs = input
                    .Split("|");

                this.commandInterpreter.AddReport(reportArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
