namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using PetStore.Services.Models.Pet;
    using Models.Pet;

    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
            => this.pets = pets;

        public IActionResult All(int page = 1)
        {
            var allPets = this.pets.All(page);
            var total = this.pets.Total();

            var model = new AllPetsViewModel
            {
                Pets = allPets,
                Total = total,
                CurrentPage = page,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var petDetails = this.pets.GetById(id);

            if (petDetails == null)
            {
                return NotFound();
            }

            if (petDetails.Description == null)
            {
                petDetails.Description = "No description";
            }

            var pdvm = new PetDetailsViewModel
            {
                Id = petDetails.Id,
                Gender = petDetails.Gender,
                DateOfBirth = petDetails.DateOfBirth,
                Description = petDetails.Description,
                Breed = petDetails.Breed,
                Category = petDetails.Category,
                Price = petDetails.Price
            };

            return this.View(pdvm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pet = this.pets
                .GetById(id);

            if (pet == null)
            {
                return BadRequest();
            }

            var pdvm = new PetDetailsViewModel
            {
                Id = pet.Id,
                Gender = pet.Gender,
                DateOfBirth = pet.DateOfBirth,
                Description = pet.Description,
                Breed = pet.Breed,
                Category = pet.Category,
                Price = pet.Price
            };

            return this.View(pdvm);
        }

        [HttpPost]
        public IActionResult Edit(PetDetailsViewModel pet)
        {
            if (!this.pets.Exists(pet.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var pdsm = new PetDetailsServiceModel
            {
                Id = pet.Id,
                Gender = pet.Gender,
                DateOfBirth = pet.DateOfBirth,
                Description = pet.Description,
                Breed = pet.Breed,
                Category = pet.Category,
                Price = pet.Price
            };

            this.pets.Edit(pdsm);

            return this.RedirectToAction("Details", "Pets", new{pdsm.Id});
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pet = this.pets.GetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var deleted = this.pets.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
