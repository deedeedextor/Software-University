namespace FastFood.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";
        private const string OrderMessage = "Order for {0} on {1} added";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var sb = new StringBuilder();

            var employees = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var position = context.Positions
                    .SingleOrDefault(p => p.Name == employeeDto.Position);

                if (position == null)
                {
                    position = new Position()
                    {
                        Name = employeeDto.Position
                    };

                    context.Positions.Add(position);
                    context.SaveChanges();
                }

                var employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                };

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var items = new List<Item>();

            var sb = new StringBuilder();

            var itemsDto = JsonConvert.DeserializeObject<ImportItemDto[]>(jsonString);

            foreach (var itemDto in itemsDto)
            {
                if (!IsValid(itemDto) || items.Any(i => i.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var category = context.Categories.SingleOrDefault(c => c.Name == itemDto.Category);

                if (category == null)
                {
                    category = new Category()
                    {
                        Name = itemDto.Category
                    };

                    context.Categories.Add(category);
                    context.SaveChanges();
                }

                var item = new Item()
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category
                };

                items.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var sb = new StringBuilder();

            var orders = new List<Order>();

            var serializer = new XmlSerializer(typeof(ImportOrderDto[]), new XmlRootAttribute("Orders"));

            var ordersDto = (ImportOrderDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var orderDto in ordersDto)
            {
                var isOrderValid = IsValid(orderDto);
                var employee = context.Employees
                    .FirstOrDefault(e => e.Name == orderDto.Employee);
                var isOrderTypeValid = Enum.IsDefined(typeof(OrderType), orderDto.Type);
                var itemsNames = context.Items
                    .Select(i => i.Name).ToList();
                var isItemsValid = orderDto.Items
                    .Select(i => i.Name)
                    .All(vi => itemsNames.Contains(vi));

                if (!isOrderValid || employee == null || !isItemsValid || !isOrderTypeValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var order = new Order()
                {
                    Customer = orderDto.Customer,
                    DateTime = DateTime.ParseExact(orderDto.DateTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Employee = employee,
                    EmployeeId = employee.Id,
                    Type = (OrderType)Enum.Parse(typeof(OrderType), orderDto.Type),
                    OrderItems = orderDto.Items
                    .Select(i => new OrderItem
                    {
                        Item = context.Items
                        .FirstOrDefault(x => x.Name == i.Name),
                        Quantity = i.Quantity
                    })
                    .ToList()
                };

                orders.Add(order);

                sb.AppendLine(string.Format(OrderMessage, order.Customer, order.DateTime.ToString(@"dd/MM/yyyy HH:mm")));
            }

            context.Orders.AddRange(orders);
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