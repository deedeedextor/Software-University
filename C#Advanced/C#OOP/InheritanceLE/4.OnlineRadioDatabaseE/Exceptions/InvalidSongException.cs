namespace _4.OnlineRadioDatabaseE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidSongException : Exception
    {
        public override string Message
        {
            get { return "Invalid song."; }
        }
    }
}
