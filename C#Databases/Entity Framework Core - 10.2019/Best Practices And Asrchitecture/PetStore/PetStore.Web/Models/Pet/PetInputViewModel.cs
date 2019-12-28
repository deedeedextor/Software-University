namespace PetStore.Web.Models.Pet
{
    using PetStore.Services.Models.Pet;
    using System.Collections.Generic;

    public class PetInputViewModel
    {
        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Breed { get; set; }

        public IEnumerable<SelectListBreed> Breeds { get; set; }

        public string Category { get; set; }
    }
}
