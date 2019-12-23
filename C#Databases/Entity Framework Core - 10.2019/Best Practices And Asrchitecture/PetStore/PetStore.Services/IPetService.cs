namespace PetStore.Services
{
    using PetStore.Models;
    using Models.Pet;
    using System;
    using System.Collections.Generic;

    public interface IPetService
    {
        PetDetailsServiceModel GetById(int id);

        IEnumerable<PetListingServiceModel> All(int page = 1);

        void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        void Edit(PetDetailsServiceModel model);

        bool Exists(int petId);

        int Total();

        bool Delete(int id);
    }
}
