namespace Solid.Appenders
{
    using Solid.Appenders.Contracts;
    using Solid.Layouts.Contracts;
    using Solid.Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }


        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(base.Layout.Format, dateTime, reportLevel, message));
                this.MessagesCount++;
            }
        }
    }
}
