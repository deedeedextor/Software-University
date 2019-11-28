﻿namespace PetStore.Services.Implementations
{
    using System.Collections.Generic;
    using Models.Brand;
    using Data;
    using PetStore.Models;
    using System;
    using System.Linq;
    using Models.Toy;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext data)
            => this.data = data;

        public int Create(string name)
        {
            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Brand name can not be more than {DataValidation.NameMaxLength} characters");
            }

            if (this.data.Brands.Any(br => br.Name == name))
            {
                throw new InvalidOperationException($"Brand name {name} already exists!");
            }

            var brand = new Brand
            {
                Name = name
            };

            this.data.Brands.Add(brand);
            this.data.SaveChanges();

            return brand.Id;
        }

        public BrandWithToysServiceModel FindByIdWithToys(int id)
            => this.data
              .Brands
            .Where(br => br.Id == id)
            .Select(br => new BrandWithToysServiceModel
            {
                Name = br.Name,
                Toys = br.Toys
                     .Select(t => new ToyListingServiceModel
                     {
                         Id = t.Id,
                         Name = t.Name,
                         Price = t.Price,
                         TotalOrders = t.Orders.Count
                     })
            })
            .FirstOrDefault();

        public IEnumerable<BrandListingServiceModel> SearchByName(string name)
            => this.data
              .Brands
              .Where(br => br.Name.ToLower().Contains(name.ToLower()))
              .Select(br => new BrandListingServiceModel
              {
                  Id = br.Id,
                  Name = br.Name
              })
            .ToList();
    }
}
