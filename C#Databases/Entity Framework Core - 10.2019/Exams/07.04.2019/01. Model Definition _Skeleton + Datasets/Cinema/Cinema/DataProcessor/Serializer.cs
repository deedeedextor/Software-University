﻿namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating
                && m.Projections.Any(p => p.Tickets.Any()))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(m => new ExportMovieDto
                {
                    MovieName = m.Title,
                    Rating = $"{m.Rating:F2}",
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections
                                 .SelectMany(p => p.Tickets)
                                 .Select(c => new ExportCustomerByMovieDto
                                 {
                                     FirstName = c.Customer.FirstName,
                                     LastName = c.Customer.LastName,
                                     Balance = c.Customer.Balance.ToString("F2")
                                 })
                                 .OrderByDescending(c => c.Balance)
                                 .ThenBy(c => c.FirstName)
                                 .ThenBy(c => c.LastName)
                                 .ToList()
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Select(c => new ExportTopCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromMilliseconds(c.Tickets
                    .Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                    .ToString(@"hh\:mm\:ss")
                })
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportTopCustomerDto[]), new XmlRootAttribute("Customers"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName()
            });

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}