using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PANDA.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required, ForeignKey(nameof(User))]
        public string RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        [Required, ForeignKey(nameof(Package))]
        public string PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
