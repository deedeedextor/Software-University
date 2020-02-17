using SharedTrip.Services;
using SharedTrip.ViewModels;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            return this.View();
        }
        
        [HttpPost]
        public HttpResponse Add(AddTripViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            if (string.IsNullOrEmpty(input.StartPoint) || string.IsNullOrEmpty(input.EndPoint))
            {
                return this.View();
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.View();
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length > 80)
            {
                return this.View();
            }

            this.tripsService.Add(this.User, input.StartPoint, input.EndPoint, input.DepartureTime, input.ImagePath, input.Seats, input.Description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            var viewModel = new AllTripsViewModel();
            viewModel.Trips = this.tripsService
                .GetAll();

            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            var viewModel = this.tripsService
                .GetById(tripId);

            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            if (this.tripsService.AddUserToCurrentTrip(this.User, tripId))
            {
                return this.Redirect("/Trips/All");
            }
            else
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }
        }
    }
}
