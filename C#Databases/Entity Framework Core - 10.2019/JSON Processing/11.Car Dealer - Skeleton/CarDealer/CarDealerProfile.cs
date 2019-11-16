using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.ImportDtos;
using CarDealer.DTO.ImportDTOs;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CarDto, Car>();

            this.CreateMap<CustomerDto, Customer>();

            this.CreateMap<SaleDto, Sale>();
        }
    }
}
