using AdoNetExercises;
using System;
using System.Data.SqlClient;
using System.Data;

namespace StoredProcedureIncreaseAge_9
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string createProcedure = @"CREATE PROC usp_GetOlder @id INT
                                         AS
                                         UPDATE Minions
                                         SET Age += 1
                                         WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(createProcedure, connection))
                {
                    command.ExecuteNonQuery();
                }

                string executeProcedure = "EXECUTE usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(executeProcedure, connection))
                {
                    command.Parameters.AddWithValue("@id", minionId);

                    command.ExecuteNonQuery();
                }

                string minionsQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", minionId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{(string)reader[0]} – {(int)reader[1]} years old");
                        }
                    }
                }
            }
        }
    }
}
