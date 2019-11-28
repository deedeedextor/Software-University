namespace PetStore.Services.Implementations
{
    using System;
    using PetStore.Data;
    using PetStore.Models;

    public class PetService : IPetService
    {
        private readonly PetStoreDbContext data;
        private readonly IBreedService breedService;
        private readonly ICategoryService categoryService;

        public PetService(PetStoreDbContext data, IBreedService breedService, ICategoryService categoryService)
        {
            this.data = data;
            this.breedService = breedService;
            this.categoryService = categoryService;
        }

        public void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price of the pet cannot be less than zero!");
            }

            if (!this.breedService.Exists(breedId))
            {
                throw new ArgumentException("Thre is no such breed with given id in the database!");
            }

            if (!this.categoryService.Exists(categoryId))
            {
                throw new ArgumentException("Thre is no such category with given id in the database!");
            }

            var pet = new Pet()
            {
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId
            };

            this.data.Pets.Add(pet);
            this.data.SaveChanges();
        }
    }
}
