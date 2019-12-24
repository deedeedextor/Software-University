namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using PetStore.Services.Models.Pet;
    using Models.Pet;
    using AutoMapper;
    using PetStore.Models;

    public class PetsController : Controller
    {
        private readonly IPetService pets;
        private readonly IMapper mapper;

        public PetsController(IPetService pets, IMapper mapper)
        {
            this.pets = pets;
            this.mapper = mapper;
        }

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
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(PetInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var pet = mapper.Map<CreatePetServiceModel>(model);

            this.pets.Create(pet);
            return RedirectToAction("All", "Pets");
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

            var pdvm = mapper.Map<PetDetailsViewModel>(petDetails);

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

            var pdvm = mapper.Map<PetDetailsViewModel>(pet);

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

            var pdsm = mapper.Map<PetDetailsServiceModel>(pet);

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
