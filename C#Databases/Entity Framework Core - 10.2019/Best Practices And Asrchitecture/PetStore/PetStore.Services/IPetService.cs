namespace PetStore.Services
{
    using PetStore.Models;
    using PetStore.Services.Models.Pet;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> All(int page = 1);

        void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
