namespace FastFood.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Export;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            var type = Enum.Parse<OrderType>(orderType);

            var employees = context
                .Employees
                .Where(e => e.Name == employeeName)
                .Select(e => new
                {
                    e.Name,
                    Orders = e.Orders.Where(o => o.Type == type).Select(o => new
                    {
                        o.Customer,
                        Items = o.OrderItems.Select(oi => new
                        {
                            oi.Item.Name,
                            oi.Item.Price,
                            oi.Quantity
                        })
                        .ToArray(),
                        TotalPrice = o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity)
                    })
                        .OrderByDescending(o => o.TotalPrice)
                        .ThenByDescending(o => o.Items.Length)
                        .ToArray(),
                    TotalMade = e.Orders
                        .Where(o => o.Type == type)
                        .Sum(o => o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity))
                })
                .SingleOrDefault();

            var json = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);

            return json;
		}//10/20

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            var splittedCategories = categoriesString.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var categories = context.Categories
                .Where(c => splittedCategories.Contains(c.Name))
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    MostPopularItem = c.Items
                    .Select(i => new ExportMostPopularItemDto
                    {
                        Name = i.Name,
                        TotalMade = i.Price * i.OrderItems.Sum(oi => oi.Quantity),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                    .OrderByDescending(i => i.TotalMade)
                    .FirstOrDefault()
                })
                .OrderByDescending(i => i.MostPopularItem.TotalMade)
                .ThenByDescending(i => i.MostPopularItem.TimesSold)
                .ToArray();

            var smlSerializer = new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var ns = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName()
            });

            smlSerializer.Serialize(new StringWriter(sb), categories, ns);

            return sb.ToString().TrimEnd();
		}
	}
}