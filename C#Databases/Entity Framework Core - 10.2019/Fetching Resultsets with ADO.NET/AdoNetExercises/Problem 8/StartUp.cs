using AdoNetExercises;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace IncreaseMinionsAge_8
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionsIds = Console.ReadLine()
                              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            string updateMinionsNames = @"UPDATE Minions
                                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                        WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateMinionsNames, connection))
                {
                    foreach (var id in minionsIds)
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                }

                string minionsNamesQuery = "SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(minionsNamesQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{(string)reader[0]} {(int)reader[1]}");
                        }
                    }
                }
            }
        }
    }
}
