using Microsoft.EntityFrameworkCore;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(string userId, string startingPoint, string endPoint, string departureTime, string imagePath, int seats, string description)
        {
            var trip = new Trip
            {
                StartPoint = startingPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = imagePath,
                Seats = seats,
                Description = description,
            };

            trip.UserTrips.Add(new UserTrip { UserId = userId, TripId = trip.Id });

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripsViewModel> GetAll()
            => this.db.Trips
            .Where(t => t.Seats > 0)
            .Select(t => new TripsViewModel
            {
                Id = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString(),
                Seats = t.Seats
            }).ToArray();

        public DetailsTripViewModel GetById(string tripId)
        {
            var viewModel = this.db.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new DetailsTripViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    ImagePath = t.ImagePath,
                    Seats = t.Seats,
                    Description = t.Description,
                })
                .FirstOrDefault();

            return viewModel;
        }

        public bool AddUserToCurrentTrip(string userId, string tripId)
        {
            var trip = this.db.Trips
                .Include(t => t.UserTrips)
                .FirstOrDefault(t => t.Id == tripId);

            bool userExists = trip.UserTrips.Any(ut => ut.UserId == userId);

            if (!userExists)
            {
                var userTrip = new UserTrip
                {
                    UserId = userId,
                    TripId = trip.Id
                };

                if (trip.Seats > 0)
                {
                    trip.Seats -= 1;
                    this.db.Update(trip);
                    this.db.UsersTrips.Add(userTrip);
                    this.db.SaveChanges();
                }

                return true;
            }

            return false;
        }
    }
}
