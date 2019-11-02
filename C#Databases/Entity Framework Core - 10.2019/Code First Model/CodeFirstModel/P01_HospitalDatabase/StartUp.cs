namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            HospitalContext db = new HospitalContext();

            db.Database.Migrate();
        }
    }
}
