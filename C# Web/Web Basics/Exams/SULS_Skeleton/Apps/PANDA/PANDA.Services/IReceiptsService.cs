using PANDA.Models;
using System.Linq;

namespace PANDA.Services
{
    public interface IReceiptsService
    {
        void CreateReceiptFromPackage(decimal weight, string packageId, string recepientId);

        IQueryable<Receipt> GetAll();
    }
}
