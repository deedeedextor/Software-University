using AdoNetExercises;
using System;
using System.Data.SqlClient;

namespace VillainNames_2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string sqlQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                  FROM Villains AS v 
                                  JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                  GROUP BY v.Id, v.Name 
                                  HAVING COUNT(mv.VillainId) > 3 
                                  ORDER BY COUNT(mv.VillainId)";

                using(SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                        }
                    }
                }
            }
        }
    }
}
