using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

            var inputXml = File.ReadAllText(@"C:\Users\Diana\Desktop\Software-University\C#Databases\Entity Framework Core - 10.2019\XML Processing\12.CarDealer - XML\CarDealer\Datasets\parts.xml");

            Console.WriteLine(ImportParts(context, inputXml));
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
    }
}