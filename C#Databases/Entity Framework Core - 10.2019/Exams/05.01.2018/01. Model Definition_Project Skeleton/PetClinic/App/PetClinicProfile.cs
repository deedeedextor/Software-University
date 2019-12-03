namespace PetClinic.App
{
    using AutoMapper;
    using PetClinic.DataProcessor.Dtos.Import;
    using PetClinic.Models;
    using System;
    using System.Globalization;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            this.CreateMap<ImportAnimalAidDto, AnimalAid>();

            this.CreateMap<ImportAnimalDto, Animal>()
                .ForMember(x => x.PassportSerialNumber, y => y.MapFrom(x => x.Passport.SerialNumber));

            this.CreateMap<ImportPassportDto, Passport>()
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(x => DateTime.ParseExact(x.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<ImportVetDto, Vet>();

            /*this.CreateMap<ImportProcedureDto, Procedure>()
                .ForPath(x => x.Vet.Name, y => y.MapFrom(x => x.Vet))
                .ForPath(x => x.Animal.Passport.SerialNumber, y => y.MapFrom(x => x.Animal))
                .ForMember(x => x.DateTime, y => y.MapFrom(x => DateTime.ParseExact(x.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                .ReverseMap();*//*

            this.CreateMap<AnimalAidDto, AnimalAid>();*/
        }
    }
}
