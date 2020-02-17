using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Add(string userId, string startingPoint, string endPoint, string departureTime, string imagePath, int seats, string description);

        IEnumerable<TripsViewModel> GetAll();

        DetailsTripViewModel GetById(string tripId);

        bool AddUserToCurrentTrip(string userId, string tripId);
    }
}