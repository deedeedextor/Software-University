namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos.Import;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data."; 
        private const string SuccessImportMessage = "Record {0} successfully imported.";
        private const string SuccessMessage = "Record {0} Passport №: {1} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var animalAids = new List<AnimalAid>();

            var animalAidsDto = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            foreach (var animalAidDto in animalAidsDto)
            {
                var isAnimalAidValid = IsValid(animalAidDto);

                var animalAid = Mapper.Map<AnimalAid>(animalAidDto);

                var alreadyExists = animalAids.Any(a => a.Name == animalAid.Name);

                if (!isAnimalAidValid || alreadyExists)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                animalAids.Add(animalAid);
                sb.AppendLine(string.Format(SuccessImportMessage, animalAid.Name));
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var animals = new List<Animal>();

            var animalsDto = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            foreach (var animalDto in animalsDto)
            {
                var animal = Mapper.Map<Animal>(animalDto);

                var isAnimalValid = IsValid(animal);

                var isPasswordValid = IsValid(animal.Passport);

                var alreadyExists = animals.Any(a => a.Passport.SerialNumber == animal.Passport.SerialNumber);

                if (!isAnimalValid || !isPasswordValid || alreadyExists)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                animals.Add(animal);
                sb.AppendLine(string.Format(SuccessMessage, animal.Name, animal.Passport.SerialNumber));
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var vets = new List<Vet>();

            var xmlserializer = new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));

            var vetsDto = (ImportVetDto[])xmlserializer.Deserialize(new StringReader(xmlString));

            foreach (var vetDto in vetsDto)
            {
                var vet = Mapper.Map<Vet>(vetDto);

                var isVetValid = IsValid(vet);

                var alreadyExists = vets.Any(v => v.PhoneNumber == vet.PhoneNumber);

                if (!isVetValid || alreadyExists)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                vets.Add(vet);
                sb.AppendLine(string.Format(SuccessImportMessage, vet.Name));
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var procedures = new List<Procedure>();

            var xmlSerializer = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var proceduresDto = (ImportProcedureDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var procedureDto in proceduresDto)
            {
                var isProcedureValid = IsValid(procedureDto);

                var animalAids = context.AnimalAids.ToHashSet();

                var vet = context.Vets
                    .Any(v => v.Name == procedureDto.Vet);

                var animalPassport = context.Animals
                    .Any(a => a.PassportSerialNumber == procedureDto.Animal);

                if (!isProcedureValid || !vet || !animalPassport)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var procedure = Mapper.Map<Procedure>(procedureDto);

                foreach (var aidDto in procedureDto.AnimalAids)
                {
                    var animalAidId = animalAids.First(aa => aa.Name == aidDto.Name).Id;

                    if (procedure.ProcedureAnimalAids.Any(paa => paa.AnimalAidId == animalAidId))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }

                    procedure.ProcedureAnimalAids.Add(new ProcedureAnimalAid { AnimalAidId = animalAidId });
                }

                procedures.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }//22/30

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
