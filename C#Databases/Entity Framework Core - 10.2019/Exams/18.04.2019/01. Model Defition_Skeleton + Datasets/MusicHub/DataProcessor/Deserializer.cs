namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var writers = new List<Writer>();

            StringBuilder sb = new StringBuilder();

            foreach (var writerDto in writersDto)
            {
                var writer = Mapper.Map<Writer>(writerDto);
                bool isWriterValid = IsValid(writer);

                if (!isWriterValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var producers = new List<Producer>();

            StringBuilder sb = new StringBuilder();

            foreach (var producerDto in producersDto)
            {
                var producer = Mapper.Map<Producer>(producerDto);

                bool isProducerValid = IsValid(producer);
                bool isAlbumValid = producerDto.Albums.Any(a => IsValid(a) == false);

                if (!isProducerValid || isAlbumValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var albumDto in producerDto.Albums)
                {
                    var album = Mapper.Map<Album>(albumDto);
                    producer.Albums.Add(album);
                }

                producers.Add(producer);

                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count()));
                }

                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone,
                        producer.Name,
                        producer.Albums.Count()));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));

            var songsDto = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var songs = new List<Song>();
            var sb = new StringBuilder();

            foreach (var songDto in songsDto)
            {
                bool isGenreValid = Enum.IsDefined(typeof(Genre), songDto.Genre);
                bool isAlbumValid = context.Albums.Any(a => a.Id == songDto.AlbumId);
                bool isWriterValid = context.Writers.Any(w => w.Id == songDto.WriterId);

                var song = Mapper.Map<Song>(songDto);
                bool isSongValid = IsValid(song);


                if (!isSongValid || !isGenreValid || !isAlbumValid || !isWriterValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                songs.Add(song);

                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));

            var performersDto = (ImportPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var performers = new List<Performer>();

            var sb = new StringBuilder();

            foreach (var performerDto in performersDto)
            {
                var performer = Mapper.Map<Performer>(performerDto);
                bool isPerformerValid = IsValid(performer);

                var songs = context.Songs
                    .Select(s => s.Id)
                    .ToList();

                var songsExists = performerDto.PerformersSongs
                    .Select(ps => ps.Id)
                    .All(x => songs.Contains(x));

                if (!isPerformerValid || !songsExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var songDto in performerDto.PerformersSongs)
                {
                    var songPerformer = new SongPerformer()
                    {
                        Performer = performer,
                        PerformerId = performer.Id,
                        Song = context.Songs.Find(songDto.Id),
                        SongId = songDto.Id
                    };

                    performer.PerformerSongs.Add(songPerformer);
                }

                performers.Add(performer);

                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count()));
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}