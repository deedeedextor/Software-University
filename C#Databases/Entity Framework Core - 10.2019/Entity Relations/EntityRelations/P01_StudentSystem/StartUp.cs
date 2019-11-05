namespace P01_StudentSystem
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new StudentSystemContext();

            context.Database.EnsureCreated();
        }
    }
}
