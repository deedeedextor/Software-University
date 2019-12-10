using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Models.Pets
{
    public class PetListingResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public decimal Price { get; set; }
    }
}
