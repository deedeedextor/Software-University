﻿namespace PetStore.Services.Implementations
{
    using Data;
    using PetStore.Models;
    using System;
    using System.Linq;
    using Models.Breed;

    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext data;

        public BreedService(PetStoreDbContext data)
            => this.data = data;

        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Breed name cannot be null or whitespace!");
            }

            var breed = new Breed()
            {
                Name = name,
            };

            this.data.Breed.Add(breed);
            this.data.SaveChanges();
        }

        public bool Exists(int breedId)
        {
            return this.data.Breed.Any(b => b.Id == breedId);
        }
    }
}
