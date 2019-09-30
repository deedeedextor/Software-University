using Solid.Appenders.Contracts;
using Solid.Layouts.Contracts;
using Solid.Loggers.Contracts;
using Solid.Loggers.Enums;
using System;
using System.IO;

namespace Solid.Appenders
{
    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";

        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; set; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message)
                    + Environment.NewLine;

                File.AppendAllText(Path, content);
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.LogFile.Size}";
        }
    }
}
