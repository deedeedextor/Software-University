using System;

namespace PetClinic.DataProcessor.Dtos.Import
{
    public class ImportPassportDto
    {
        public string SerialNumber { get; set; }

        public string OwnerName { get; set; }

        public string OwnerPhoneNumber { get; set; }

        public string RegistrationDate { get; set; }
    }
}