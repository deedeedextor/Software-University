namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new ExportPrisonerByCellDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(po => new ExportOfficerByPrisonerDto
                    {
                        FullName = po.Officer.FullName,
                        Department = po.Officer.Department.Name,
                    })
                    .OrderBy(o => o.FullName)
                    .ToList(),
                    TotalOfficerSalary = p.PrisonerOfficers
                    .Sum(po => po.Officer.Salary)
                })
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(prisoners, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var splittedPrisonersNames = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var prisoners = context.Prisoners
                .Where(p => splittedPrisonersNames.Contains(p.FullName))
                .Select(p => new ExportPrisonerByMailDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                    .Select(m => new ExportMailDto
                    {
                        Description = Reverse(m.Description),
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportPrisonerByMailDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();

            var ns = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(),
            });

            serializer.Serialize(new StringWriter(sb), prisoners, ns);

            return sb.ToString().TrimEnd();
        }

        private static string Reverse(string description)
        {
            char[] charArray = description.ToCharArray();

            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string Reverse()
        {
            throw new NotImplementedException();
        }
    }
}