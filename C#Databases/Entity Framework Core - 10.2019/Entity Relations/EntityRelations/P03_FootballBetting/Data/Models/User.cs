namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(30), Column(TypeName = "VARCHAR(30)")]
        public string Username { get; set; }

        [Required, MaxLength(30), Column(TypeName = "VARCHAR(30)")]
        public string Password { get; set; }

        [Required, MaxLength(30), Column(TypeName = "VARCHAR(30)")]
        public string Email { get; set; }

        [Required, MaxLength(30), Column(TypeName = "VARCHAR(30)")]
        public string Name { get; set; }

        [Required, Range(0.001, 999999.9)]
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
    }
}