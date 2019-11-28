﻿namespace PetStore
{
    using Data;
    using Services.Implementations;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            using var data = new PetStoreDbContext();

            var breedService = new BreedService(data);
            var categoryService = new CategoryService(data);
            var userService = new UserService(data);

            var petService = new PetService(data, breedService, categoryService, userService);
            //petService.BuyPet(Models.Gender.Female, DateTime.Now, 30.89m, null, 1, 1);
            petService.SellPet(1, 3);


            //breedService.Add("Persian");

            /*var brandService = new BrandService(data);

            var brandWithToys = brandService.FindByIdWithToys(1);*/

            //var toyService = new ToyService(data, userService);

            //userService.Register("Maria", "mar123@abv.bg");

            //toyService.SellToyToUser(1, 3);

            /*foodService.BuyFromDistributor("Cat food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 1);*/

            /*var toyService = new ToyService(data);

            toyService.BuyFromDistributor("Ball", null, 3.50m, 0.3, 1, 1);*/
        }
    }
}
