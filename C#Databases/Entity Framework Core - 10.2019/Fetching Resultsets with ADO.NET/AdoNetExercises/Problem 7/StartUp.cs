using AdoNetExercises;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PrintAllMinionsNames_7
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> minionNames = new List<string>();

            string namesQuery = "SELECT Name FROM Minions";

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(namesQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minionNames.Add((string)reader[0]);
                        }
                    }
                }
            }

            Console.WriteLine($"Original order:\n{string.Join(Environment.NewLine, minionNames)}");
            Console.WriteLine("Output:");

            while (minionNames.Count != 0)
            {
                Console.WriteLine(minionNames[0]);
                minionNames.RemoveAt(0);

                if (minionNames.Count == 0)
                {
                    break;
                }

                Console.WriteLine(minionNames.Last());
                minionNames.RemoveAt(minionNames.Count - 1);
            }
        }
    }
}
