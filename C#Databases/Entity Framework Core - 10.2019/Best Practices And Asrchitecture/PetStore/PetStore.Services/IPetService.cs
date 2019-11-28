namespace PetStore.Services
{
    using PetStore.Models;
    using System;

    public interface IPetService
    {
        void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId);


    }
}
