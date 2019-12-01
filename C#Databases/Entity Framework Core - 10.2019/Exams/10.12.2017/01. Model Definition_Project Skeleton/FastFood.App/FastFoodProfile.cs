namespace FastFood.App
{
    using AutoMapper;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using System;

    public class FastFoodProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public FastFoodProfile()
		{
            this.CreateMap<ImportEmployeeDto, Employee>();
		}
	}
}
