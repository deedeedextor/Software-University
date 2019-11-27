namespace PetStore
{
    using Microsoft.EntityFrameworkCore;
    using PerStore.Data;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new PetStoreDbContext();

            context.Database.Migrate();
        }
    }
}
