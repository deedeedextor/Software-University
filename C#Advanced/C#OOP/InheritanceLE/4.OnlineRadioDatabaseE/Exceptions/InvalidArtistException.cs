namespace _4.OnlineRadioDatabaseE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidArtistException : InvalidSongException
    {
        public override string Message
        {
            get { return "Artist name should be between 3 and 20 symbols."; }
        }
    }
}
