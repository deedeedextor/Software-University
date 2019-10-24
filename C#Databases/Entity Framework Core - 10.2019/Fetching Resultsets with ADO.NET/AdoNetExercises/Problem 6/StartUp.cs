using AdoNetExercises;
using System;
using System.Data.SqlClient;

namespace RemoveVillain_6
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            string villainName = null;

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";

                using (SqlCommand command = new SqlCommand(villainNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                string deleteMinionsVillains = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

                using (SqlCommand command = new SqlCommand(deleteMinionsVillains, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    int minionCount = command.ExecuteNonQuery();

                    string deleteVillain = "DELETE FROM Villains WHERE Id = @villainId";

                    using (SqlCommand command1 = new SqlCommand(deleteVillain, connection))
                    {
                        command1.Parameters.AddWithValue("@villainId", villainId);
                        command1.ExecuteNonQuery();
                    }

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionCount} minions were released.");
                }
            }
        }
    }
}
