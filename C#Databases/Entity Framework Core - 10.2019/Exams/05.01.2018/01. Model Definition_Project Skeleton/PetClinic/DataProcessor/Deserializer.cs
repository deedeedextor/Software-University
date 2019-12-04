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
            /*var xDoc = XDocument.Parse(xmlString);
            var elements = xDoc.Root.Elements();

            var sb = new StringBuilder();
            var validEntries = new List<Procedure>();

            foreach (var el in elements)
            {
                string vetName = el.Element("Vet")?.Value;
                string passportId = el.Element("Animal")?.Value;
                string dateTimeString = el.Element("DateTime")?.Value;

                int? vetId = context.Vets.SingleOrDefault(v => v.Name == vetName)?.Id;
                bool passportExists = context.Passports.Any(p => p.SerialNumber == passportId);

                bool dateIsValid = DateTime
                    .TryParseExact(dateTimeString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                var animalAidElements = el.Element("AnimalAids")?.Elements();

                if (vetId == null || !passportExists || animalAidElements == null || !dateIsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animalAidIds = new List<int>();
                bool allAidsExist = true;

                foreach (var aid in animalAidElements)
                {
                    string aidName = aid.Element("Name")?.Value;

                    int? aidId = context.AnimalAids.SingleOrDefault(a => a.Name == aidName)?.Id;

                    if (aidId == null || animalAidIds.Any(id => id == aidId))
                    {
                        allAidsExist = false;
                        break;
                    }

                    animalAidIds.Add(aidId.Value);
                }

                if (!allAidsExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var procedure = new Procedure()
                {
                    VetId = vetId.Value,
                    AnimalId = context.Animals.Single(a => a.PassportSerialNumber == passportId).Id,
                    DateTime = dateTime,
                };

                foreach (var id in animalAidIds)
                {
                    var mapping = new ProcedureAnimalAid()
                    {
                        Procedure = procedure,
                        AnimalAidId = id
                    };

                    procedure.ProcedureAnimalAids.Add(mapping);
                }

                bool isValid = IsValid(procedure);

                if (!isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validEntries.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(validEntries);
            context.SaveChanges();*/

            var sb = new StringBuilder();

            var procedures = new List<Procedure>();

            var xmlSerializer = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var proceduresDto = (ImportProcedureDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var procedureDto in proceduresDto)
            {
                var isProcedureValid = IsValid(procedureDto);
                var isAnimalAidsValid = IsValid(procedureDto.AnimalAids);

                /*var allAnimalAids = context.AnimalAids
                    .Select(aa => aa.Name)
                    .ToArray();*/

                /* var vetExists = context.Vets
                     .Any(v => v.Name == procedureDto.Vet);*/

                var vet = context.Vets
                    .FirstOrDefault(v => v.Name == procedureDto.Vet);

                /*var animalPassportExists = context.Animals
                    .Any(a => a.Passport.SerialNumber == procedureDto.Animal);*/

                var animalPassport = context.Animals
                    .FirstOrDefault(a => a.PassportSerialNumber == procedureDto.Animal);

                if (!isProcedureValid || !isAnimalAidsValid || vet == null || animalPassport == null)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var procedure = Mapper.Map<Procedure>(procedureDto);

                /*var procedure = new Procedure()
                {
                    Vet = vet,
                    Animal = animalPassport,
                    DateTime = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };*/

                foreach (var aidDto in procedureDto.AnimalAids)
                {
                    if (procedureDto.AnimalAids.Any(aa => aa.Name == aidDto.Name) || context.AnimalAids.FirstOrDefault(aa => aa.Name == aidDto.Name) == null)
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }

                    var animalAid = Mapper.Map<AnimalAid>(aidDto);

                    var procedureAnimalAid = new ProcedureAnimalAid()
                    {
                        Procedure = procedure,
                        AnimalAidId = animalAid.Id
                    };

                    procedure.ProcedureAnimalAids.Add(procedureAnimalAid);
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
