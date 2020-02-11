using PANDA.Data;
using PANDA.Models;
using PANDA.Models.Enums;
using System.Linq;

namespace PANDA.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly PANDAContext db;
        private readonly IReceiptsService receiptsService;

        public PackagesService(PANDAContext db, IReceiptsService receiptsService)
        {
            this.db = db;
            this.receiptsService = receiptsService;
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

        public void Deliver(string id)
        {
            var package = this.db.Packages
                .FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.db.SaveChanges();

            this.receiptsService.CreateReceiptFromPackage(package.Weight, package.Id, package.RecepientId);
        }

        public IQueryable<Package> GetAllPackagesByStatus(PackageStatus status)
        {
            var packages = this.db.Packages
            .Where(p => p.Status == status);

            return packages;
        }
    }
}
