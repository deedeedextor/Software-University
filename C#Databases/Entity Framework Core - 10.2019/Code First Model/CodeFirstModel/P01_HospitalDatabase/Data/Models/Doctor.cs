namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}
