namespace FastFood.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using AutoMapper;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using Newtonsoft.Json;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            foreach (var employeeDto in employeesDto)
            {
                var employee = Mapper.Map<Employee>(employeeDto);

            }

            return null;
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}