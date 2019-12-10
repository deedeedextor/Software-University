namespace PetStore
{
    using Data;
    using PetStore.Models;
    using Services.Implementations;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            using var data = new PetStoreDbContext();

            for (int i = 0; i < 10; i++)
            {
                var breed = new Breed
                {
                    Name = "Breed" + i
                };

                data.Breed.Add(breed);
            }

            data.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                var category = new Category
                {
                    Name = "Category" + i,
                    Description = "Category Description" + i,
                };

                data.Categories.Add(category);
            }

            data.SaveChanges();

            for (int i = 0; i < 50; i++)
            {
                var categoryId = data
                    .Categories
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => c.Id)
                    .FirstOrDefault();

                var breedId = data
                    .Breed
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => c.Id)
                    .FirstOrDefault();

                var pet = new Pet
                {
                    DateOfBirth = DateTime.UtcNow.AddDays(-60 + i),
                    Price = 50 + i,
                    Gender = (Gender)(i % 2),
                    Description = "Some random description" + i,
                    CategoryId = categoryId,
                    BreedId = breedId,
                };

                data.Pets.Add(pet);
            }

            data.SaveChanges();

            /*var breedService = new BreedService(data);
            var categoryService = new CategoryService(data);
            var userService = new UserService(data);

            var petService = new PetService(data, breedService, categoryService, userService);*/
            //petService.BuyPet(Models.Gender.Female, DateTime.Now, 30.89m, null, 1, 1);
            //petService.SellPet(1, 3);


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
