namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportWriterDto, Writer>();

            this.CreateMap<ImportProducerDto, Producer>()
                .ForMember(x => x.Albums, y => y.MapFrom(z => new HashSet<Album>()));

            this.CreateMap<ImportAlbumDto, Album>()
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(z => DateTime.ParseExact(z.ReleaseDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<ImportSongDto, Song>()
                .ForMember(x => x.Duration, y => y.MapFrom(
                    z => TimeSpan.ParseExact(z.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CreatedOn, y => y.MapFrom(
                    z => DateTime.ParseExact(z.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Genre, y => y.MapFrom(z => Enum.Parse(typeof(Genre), z.Genre)));

            this.CreateMap<ImportPerformerDto, Performer>();
        }
    }
}
