namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            /*The given method in the project skeleton receives a producer id.Export all albums which are produced by the provided producer id.For each album, get the name, release date in format "MM/dd/yyyy", producer name, the album songs with each song name, price formatted to the second digit and the song writer name. Sort the songs by song name(descending) and by writer(ascending).At the end export the total album price with exactly two digits after the decimal place. Sort the albums by their price(descending).*/

            throw new NotImplementedException();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}