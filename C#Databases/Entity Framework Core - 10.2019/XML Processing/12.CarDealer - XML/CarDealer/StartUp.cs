using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            var context = new CarDealerContext();

            //context.Database.EnsureCreated();

            //var inputXml = File.ReadAllText(@"C:\Users\Diana\Desktop\Software-University\C#Databases\Entity Framework Core - 10.2019\XML Processing\12.CarDealer - XML\CarDealer\Datasets\sales.xml");

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                var supplier = context.Suppliers.Find(partDto.SupplierId);

                if (supplier != null)
                {
                    var part = Mapper.Map<Part>(partDto);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            var carsDto = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);

                context.Cars.Add(car);

                foreach (var part in carDto.Parts.PartsId)
                {
                    if (car.PartCars
                        .FirstOrDefault(p => p.PartId == part.PartId) == null &&
                        context.Parts.Find(part.PartId) != null)
                    {
                        var partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part.PartId
                        };

                        car.PartCars.Add(partCar);
                    }
                }

                cars.Add(car);
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }//Memory Limit

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            var salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                var targetCar = context.Cars.FirstOrDefault(c => c.Id == saleDto.CarId);

                if (targetCar != null)
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
            ;
            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                 .Where(c => c.TravelledDistance > 2000000)
                 .OrderBy(c => c.Make)
                 .ThenBy(c => c.Model)
                 .Take(10)
                 .Select(c => new ExportCarWithDistanceDto
                 {
                     Make = c.Make,
                     Model = c.Model,
                     TravelledDistance = c.TravelledDistance
                 })
                 .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), new XmlRootAttribute("cars"));

            var namespases = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(),
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespases);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarsBWMDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarsBWMDto[]), new XmlRootAttribute("cars"));

            var namespases = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(),
            });

            xmlSerializer.Serialize(new StringWriter(sb), bmwCars, namespases);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(),
            });

            var xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), new XmlRootAttribute("suppliers"));
            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsParts = context.Cars
                 .Select(c => new ExportCarWithDistanceDto
                 {
                     Make = c.Make,
                     Model = c.Model,
                     TravelledDistance = c.TravelledDistance,
                     Parts = c.PartCars
                              .Select(p => new ExportPartDto
                              {
                                  Name = p.Part.Name,
                                  Price = p.Part.Price
                              })
                              .OrderByDescending(p => p.Price)
                              .ToArray()
                 })
                 .OrderByDescending(c => c.TravelledDistance)
                 .ThenBy(c => c.Model)
                 .Take(5)
                 .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(),
            });

            xmlSerializer.Serialize(new StringWriter(sb), carsParts, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpendMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(cp => cp.Part.Price)
                })
                .OrderByDescending(c => c.SpendMoney)
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("customers"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(),
            });

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                 .Select(s => new ExportSaleDto
                 {
                     Car = new CarDto
                     {
                         Make = s.Car.Make,
                         Model = s.Car.Model,
                         TravelledDistance = s.Car.TravelledDistance
                     },
                     Discount = s.Discount,
                     CustomerName = s.Customer.Name,
                     Price = s.Car.PartCars.Sum(p => p.Part.Price),
                     PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) -
                        s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100
                     //s.Car.Parts.Sum(p => p.Price) * (1 - s.Discount)
                 })
                 .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportSaleDto[]), new XmlRootAttribute("sales"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty 
            });

            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}