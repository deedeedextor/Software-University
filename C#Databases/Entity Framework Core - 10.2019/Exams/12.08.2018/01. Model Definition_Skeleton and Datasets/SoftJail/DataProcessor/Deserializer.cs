namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string ImportedDepartment = "Imported {0} with {1} cells";
        private const string ImportedPrisoner = "Imported {0} {1} years old";
        private const string ImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var departments = new List<Department>();

            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            foreach (var departmentDto in departmentsDto)
            {
                var department = Mapper.Map<Department>(departmentDto);

                var isDepartmentValid = IsValid(department);

                var isCellsValid = department
                    .Cells
                    .Any(c => !IsValid(c));

                if (!isDepartmentValid || isCellsValid)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                departments.Add(department);
                sb.AppendLine(string.Format(ImportedDepartment, department.Name, department.Cells.Count()));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var prisoners = new List<Prisoner>();

            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            foreach (var prisonerDto in prisonersDto)
            {
                var prisoner = Mapper.Map<Prisoner>(prisonerDto);

                var isPrisonerValid = IsValid(prisoner);

                var isMailsValid = prisoner
                    .Mails
                    .Any(m => IsValid(m) == false);

                if (!isPrisonerValid || isMailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(prisoner);
                sb.AppendLine(string.Format(ImportedPrisoner, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var officers = new List<Officer>();

            var serializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var officerDto in officersDto)
            {
                var isPositionValid = Enum.IsDefined(typeof(Position), officerDto.Position);

                var isWeaponValid = Enum.IsDefined(typeof(Weapon), officerDto.Weapon);

                if (!isPositionValid || !isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = Mapper.Map<Officer>(officerDto);

                var isOfficerValid = IsValid(officer);

                if (!isOfficerValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                officer.OfficerPrisoners = officerDto
                    .Prisoners
                    .Select(p => new OfficerPrisoner { PrisonerId = p.Id })
                    .ToList();

                officers.Add(officer);

                sb.AppendLine(string.Format(ImportedOfficer, officer.FullName, officer.OfficerPrisoners.Count()));
            }

            context.Officers.AddRange(officers);
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