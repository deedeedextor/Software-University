using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            var context = new ProductShopContext();

            //context.Database.EnsureCreated();

            //string inputXml = File.ReadAllText(@"C:\Users\Diana\Desktop\Software-University\C#Databases\Entity Framework Core - 10.2019\XML Processing\12.ProductShop - XML\ProductShop\Datasets\categories-products.xml");

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);

                if (targetCategory != null && targetProduct != null)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(categoryProductDto);
                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductInRange
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .ToArray();

            var sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRange[]), new XmlRootAttribute("Products"));

            var namespases = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespases);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserWithSoldItemDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                   .Select(ps => new ExportSoldProductDto
                                   {
                                       Name = ps.Name,
                                       Price = ps.Price
                                   })
                                   .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserWithSoldItemDto[]), new XmlRootAttribute("Users"));

            var namespases = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespases);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var namespases = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespases);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserAndProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProductDto = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count,
                        SoldProducts = u.ProductsSold
                                        .Select(ps => new ExportSoldProductDto
                                        {
                                            Name = ps.Name,
                                            Price = ps.Price
                                        })
                                        .OrderByDescending(ps => ps.Price)
                                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProductDto.Count)
                .ToArray();

            var customExport = new ExportCustomUserProductDto
            {
                Count = users.Length,
                UsesAndProducts = users
            };

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespases = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            xmlSerializer.Serialize(new StringWriter(sb), customExport, namespases);

            return sb.ToString().TrimEnd();
        }// - 50/100
    }
}