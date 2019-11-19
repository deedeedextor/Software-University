namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
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

        }
    }
}
