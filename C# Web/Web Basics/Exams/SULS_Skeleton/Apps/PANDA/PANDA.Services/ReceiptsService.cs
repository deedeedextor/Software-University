using PANDA.Data;
using PANDA.Models;
using System;
using System.Linq;

namespace PANDA.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly PANDAContext db;

        public ReceiptsService(PANDAContext db)
        {
            this.db = db;
        }

        public void CreateReceiptFromPackage(decimal weight, string packageId, string recepientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recepientId,
                Fee = weight * 2.67M,
                IssuedOn = DateTime.UtcNow,
            };

            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.db.Receipts;
        }
    }
}
