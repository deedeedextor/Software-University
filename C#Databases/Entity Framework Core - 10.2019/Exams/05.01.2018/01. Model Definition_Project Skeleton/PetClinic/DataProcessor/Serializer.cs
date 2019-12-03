namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos.Export;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(a => new
                {
                    OwnerName = a.Passport.OwnerName,
                    AnimalName = a.Name,
                    Age = a.Age,
                    SerialNumber = a.PassportSerialNumber,
                    RegisteredOn = a.Passport.RegistrationDate.ToString(@"dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(a => a.Age)
                .ThenBy(a => a.SerialNumber)
                .ToList();

            var json = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .Select(p => new ExportProcedureDto
                {
                    Passport = p.Animal.PassportSerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = p.ProcedureAnimalAids
                    .Select(aa => new ExportAnimalAid
                    {
                        Name = aa.AnimalAid.Name,
                        Price = aa.AnimalAid.Price
                    })
                    .ToArray(),
                    TotalPrice = p.ProcedureAnimalAids.Sum(aa => aa.AnimalAid.Price)
                })
                .OrderBy(p => DateTime.ParseExact(p.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .ThenBy(p => p.Passport)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var ns = new XmlSerializerNamespaces(new []{XmlQualifiedName.Empty});

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), procedures, ns);

            return sb.ToString().TrimEnd();
        }
    }
}
