namespace PetStore.Web.MappingConfiguration
{
    using AutoMapper;
    using PetStore.Models;
    using PetStore.Services.Models.Pet;
    using PetStore.Web.Models.Pet;
    using System;
    using System.Globalization;

    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            this.CreateMap<PetDetailsServiceModel, PetDetailsViewModel>();

            this.CreateMap<PetDetailsViewModel, PetDetailsServiceModel>();

            this.CreateMap<PetInputViewModel, CreatePetServiceModel>();

            this.CreateMap<CreatePetServiceModel, Pet>()
                .ForMember(x => x.Gender, y => y.MapFrom(x => Enum.Parse(typeof(Gender), x.Gender)))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(x => DateTime.ParseExact(x.DateOfBirth, @"MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForPath(x => x.Breed.Name, y => y.MapFrom(x => x.Breed))
                .ForPath(x => x.Category.Name, y => y.MapFrom(x => x.Category))
                .ReverseMap();
        }
    }
}
