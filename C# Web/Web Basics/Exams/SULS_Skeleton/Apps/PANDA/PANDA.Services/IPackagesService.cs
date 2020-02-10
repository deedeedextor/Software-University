using PANDA.Models;

namespace PANDA.Services
{
    public interface IPackagesService
    {
        void CreatePackage(string decription, decimal weight, string shippingAddress, string recipient);
    }
}
