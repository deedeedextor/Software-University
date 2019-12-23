namespace PetStore.Web.Models.Pet
{
    public class PetInputViewModel
    {
        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Breed { get; set; }

        public string Category { get; set; }

        public int? OrderId { get; set; }
    }
}
