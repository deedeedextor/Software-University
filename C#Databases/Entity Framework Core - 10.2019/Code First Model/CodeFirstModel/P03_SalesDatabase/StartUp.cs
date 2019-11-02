﻿namespace P03_SalesDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SalesContext db = new SalesContext();

            db.Database.Migrate();
        }
    }
}
