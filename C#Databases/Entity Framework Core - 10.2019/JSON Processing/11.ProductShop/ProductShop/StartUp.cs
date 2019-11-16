using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
                    .Select(p => new SoldProductsResultModel
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName,
                    })
                    .ToList()
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new CategoryResultModel
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):F2}",
                    /*c.CategoryProducts
                    .Select(cp => cp.Product.Price)
                    .Average(),*/
                    TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):F2}"
                    /*c.CategoryProducts
                    .Select(cp => cp.Product.Price)
                    .Sum(),*/
                })
                .ToList();

            var json = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },

                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                //.OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new UserProductsResultModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsToUserResultModel
                    {
                        Count = u.ProductsSold
                                 .Where(p => p.Buyer != null)
                                 .Count(),
                        Products = u.ProductsSold
                                  .Where(p => p.Buyer != null)
                                  .Select(ps => new SoldProductsResultModel
                                  {
                                     Name = ps.Name,
                                     Price = ps.Price
                                  })
                                  .ToList()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            var result = new UserWithProductsResultModel
            {
                UsersCount = users.Count,
                Users = users
            };

            var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },

                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}