using PANDA.Data;
using PANDA.Models;
using PANDA.Models.Enums;
using System.Linq;

namespace PANDA.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly PANDAContext db;

        public PackagesService(PANDAContext db)
        {
            this.db = db;
        }

        public void CreatePackage(string description, decimal weight, string shippingAddress, string recipient)
        {
            var userId = this.db.Users
                .Where(u => u.Username == recipient)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                ShippingAddress = shippingAddress,
                RecepientId = userId,
                Status = PackageStatus.Pending,
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }
    }
}
