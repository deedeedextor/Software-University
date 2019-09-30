namespace _4.OnlineRadioDatabaseE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidSongLengthException : InvalidSongException
    {
        public override string Message
        {
            get { return "Invalid song length."; }
        }
    }
}
