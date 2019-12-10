using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Services.Models.Pet;
using System.Collections.Generic;

namespace PetStore.Web.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
            => this.pets = pets;

        //public IEnumerable<PetListingServiceModel> All()
            //=> this.pets.All();

        public IActionResult All(int page = 1)
        {
            var allPets = this.pets.All(page);
            return View(allPets);
        }
    }
}
