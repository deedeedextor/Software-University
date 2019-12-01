namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
	{
        public int Id { get; set; }

        [Required, StringLength(30), MinLength(3)]
        public string Name { get; set; }

        [Required, Range(15, 80)]
        public int Age { get; set; }

        [Required, ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}