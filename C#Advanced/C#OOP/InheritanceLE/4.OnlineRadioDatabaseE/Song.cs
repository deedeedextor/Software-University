namespace _4.OnlineRadioDatabaseE
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    public class Song
    {
        private const int ArtistMinLength = 3;
        private const int ArtistMaxLength = 20;
        private const int SongMinLength = 3;
        private const int SongMaxLength = 30;
        private const int MinutesMin = 0;
        private const int MinutesMax = 14;
        private const int SecondsMin = 0;
        private const int SecondsMax = 59;

        private string artist;
        private string songName;
        private int minutes;
        private int seconds;

        public Song(string artist, string songName, int minutes, int seconds)
        {
            this.Artist = artist;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string Artist
        {
            get
            {
                return this.artist;
            }

            private set
            {
                if (value.Length < ArtistMinLength || value.Length > ArtistMaxLength)
                {
                    throw new InvalidArtistException();
                }

                this.artist = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }

            set
            {
                if (value.Length < SongMinLength || value.Length > SongMaxLength)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        public int Minutes
        {
            get { return this.minutes; }

            set
            {
                if (value < MinutesMin || value > MinutesMax)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get { return this.seconds; }

            set
            {
                if (value < SecondsMin || value > SecondsMax)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
    }
}
