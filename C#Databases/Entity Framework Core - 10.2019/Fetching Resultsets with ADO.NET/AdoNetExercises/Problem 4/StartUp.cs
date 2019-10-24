﻿using AdoNetExercises;
using System;
using System.Data.SqlClient;

namespace AddMinion_4
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] minionProps = Console.ReadLine().Split();
            string[] villainProps = Console.ReadLine().Split();

            string minionName = minionProps[1];
            int age = int.Parse(minionProps[2]);
            string town = minionProps[3];

            string villainName = villainProps[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownByName(connection, town);

                if (townId == null)
                {
                    AddTown(connection, town);
                }

                townId = GetTownByName(connection, town);

                AddMinion(connection, minionName, age, townId);

                int? villainId = GetVillainByName(villainName, connection);

                if (villainId == null)
                {
                    AddVillain(connection, villainName);
                }

                villainId = GetVillainByName(villainName, connection);

                int minionId = GetMinionByName(connection, minionName);

                AddMinionVillain(connection, villainId, minionId);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void AddMinionVillain(SqlConnection connection, int? villainId, int minionId)
        {
            string insertMinionVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(insertMinionVillain, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);

                command.ExecuteNonQuery();
            }
        }

        private static int GetMinionByName(SqlConnection connection, string minionName)
        {
            string minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(minionIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);

                return (int)command.ExecuteScalar();
            }
        }

        private static int? GetVillainByName(string villainName, SqlConnection connection)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(villainIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);

                return (int?)command.ExecuteScalar();
            }
        }

        private static int? GetTownByName(SqlConnection connection, string town)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";

            using (SqlCommand command = new SqlCommand(townIdQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", town);

                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int age, int? townId)
        {
            string insertMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertMinion, connection))
            {
                command.Parameters.AddWithValue("@nam", minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertVillainSql = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using (SqlCommand command = new SqlCommand(insertVillainSql, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private static void AddTown(SqlConnection connection, string town)
        {
            string insertTownSql = "INSERT INTO Towns (Name) VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(insertTownSql, connection))
            {
                command.Parameters.AddWithValue("@townName", town);
                command.ExecuteNonQuery();

                Console.WriteLine($"Town {town} was added to the database.");
            }
        }
    }
}
