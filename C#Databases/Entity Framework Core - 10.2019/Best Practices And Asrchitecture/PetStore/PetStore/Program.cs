namespace PetStore
{
    using Data;
    using Services.Implementations;

    public class Program
    {
        public static void Main(string[] args)
        {
            using var data = new PetStoreDbContext();

            var brandService = new BrandService(data);

            var brandWithToys = brandService.findByIdWithToys(1);
        }
    }
}
