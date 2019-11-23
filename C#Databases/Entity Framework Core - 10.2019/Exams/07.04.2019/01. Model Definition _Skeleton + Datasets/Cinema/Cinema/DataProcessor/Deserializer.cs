namespace Cinema.DataProcessor
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
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var movies = new List<Movie>();
            var sb = new StringBuilder();

            foreach (var movieDto in moviesDto)
            {
                var isMovieValid = IsValid(movieDto);
                var isMovieExists = context.Movies
                    .Any(m => m.Title == movieDto.Title);

                if (!isMovieValid || isMovieExists == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = Mapper.Map<Movie>(movieDto);
                movies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallWithSeats[]>(jsonString);

            var halls = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var hallDto in hallsDto)
            {
                var isHallValid = IsValid(hallDto);

                if (!isHallValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                var projectionType = string.Empty;

                if (hall.Is4Dx == true && hall.Is3D == true)
                {
                    projectionType = "4Dx/3D";
                }

                else if (hall.Is3D == true)
                {
                    projectionType = "3D";
                }

                else if (hall.Is4Dx == true)
                {
                    projectionType = "4Dx";
                }

                else
                {
                    projectionType = "Normal";
                }

                halls.Add(hall);

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count()));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Projection>();

            var sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                var projection = Mapper.Map<Projection>(projectionDto);

                var isProjectionValid = IsValid(projection);

                var targetMovie = context.Movies
                    .Find(projection.MovieId);

                var targetHall = context.Halls
                    .Find(projection.HallId);

                if (targetMovie == null || targetHall == null || !isProjectionValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                projections.Add(projection);

                sb.AppendLine(string.Format(SuccessfulImportProjection, targetMovie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var customers = new List<Customer>();

            var sb = new StringBuilder();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);

                var isCustomerValid = IsValid(customer);

                var projections = context.Projections.Select(x => x.Id).ToArray();
                var isValidProjection = projections
                    .Any(p => customerDto.Tickets.Any(c => c.ProjectionId != p));

                if (!isCustomerValid || !isValidProjection)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                customers.Add(customer);

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count()));
            }

            context.Customers.AddRange(customers);
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