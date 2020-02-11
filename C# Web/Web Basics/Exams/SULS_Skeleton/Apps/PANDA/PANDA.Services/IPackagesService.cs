using PANDA.Models;
using PANDA.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PANDA.Services
{
    public interface IPackagesService
    {
        void CreatePackage(string decription, decimal weight, string shippingAddress, string recipient);

        IQueryable<Package> GetAllPackagesByStatus(PackageStatus status);

        void Deliver(string id);
    }
}
