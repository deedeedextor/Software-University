using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //var categoryProductsJson = File.ReadAllText(@"C:\Users\Diana\OneDrive\DKProject\CSharp\C# DB\Entity Framework Core\11.Product Shop - Skeleton\ProductShop\Datasets\categories-products.json");

            Console.WriteLine(GetCategoriesByProductsCount(db));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            var validUsers = new List<User>();

            foreach (var user in users)
            {
                if (user.LastName == null || user.LastName.Length < 3)
                {
                    continue;
                }

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            var countOfSavedUsers = context.SaveChanges();
            return $"Successfully imported {countOfSavedUsers}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            var countProducts = context.SaveChanges();

            return $"Successfully imported {countProducts}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null);

            context.Categories.AddRange(categories);
            var countCategories = context.SaveChanges();

            return $"Successfully imported {countCategories}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            var countCategoryProducts = context.SaveChanges();

            return $"Successfully imported {countCategoryProducts}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductResultModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .OrderBy(p => p.Price)
                .ToList();

            var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(sp => sp.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserResultModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new SoldProductResultModel
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName,
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            // TO DO - Round averagePrice, totalRevenue
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new CategoryResultModel
                {
                    Category = c.Name,
                    ProductCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts
                    .Select(cp => cp.Product.Price)
                    .Average(),
                    TotalRevenue = c.CategoryProducts
                    .Select(cp => cp.Product.Price)
                    .Sum(),
                })
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }
    }
}