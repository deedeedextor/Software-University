﻿namespace PetStore.Services.Models.Pet
{
    public class PetDetailsServiceModel
    {
        public int Id { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Breed { get; set; }

        public string Category { get; set; }
    }
}
