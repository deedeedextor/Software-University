namespace VaporStore
{
	using AutoMapper;
    using System;
    using System.Globalization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enumerations;
    using VaporStore.DataProcessor.ImportDto;

    public class VaporStoreProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public VaporStoreProfile()
		{
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<ImportCardDto, Card>()
                .ForMember(x => x.Type, y => y.MapFrom(z => Enum.Parse(typeof(CardType), z.Type)));

            this.CreateMap<ImportPurchaseDto, Purchase>()
                .ForMember(x => x.Type, y => y.MapFrom(x => Enum.Parse(typeof(PurchaseType), x.Type)))
                .ForMember(x => x.Date, y => y.MapFrom(x => DateTime.ParseExact(x.Date, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(x => x.ProductKey, y => y.MapFrom(x => x.Key));
		}
	}
}