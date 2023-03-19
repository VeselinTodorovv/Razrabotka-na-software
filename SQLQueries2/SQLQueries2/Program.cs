using System;
using System.Data.SqlClient;

namespace SQLQueries2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection("Server=.;Database=Minions;Integrated Security = true");
            using (connection)
            {
                connection.Open();

                SqlCommand cmd1 = new SqlCommand(
                    "SELECT V.Name, COUNT(MV.Villain.Id)" +
                    "FROM Villains as V" + 
                    "JOIN MinionsVillains AS MV on MV.Villain.Id = V.Id" +
                    "GROUP BY MV.VillainId, V.Name" +
                    "HAVING COUNT(MV.VillainId) > 3",
                    connection
                );
                var reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} -> {reader[1]}");
                }
            }

            //Problem 3
            int villainID = int.Parse(Console.ReadLine());
            using (connection)
            {
                connection.Open();

                SqlCommand sql1 = new SqlCommand(
                    "SELECT minions.name" +
                    "FROM minionsvillains" + 
                    "JOIN minions on minionsvillains.MinionId = minions.Id" +
                    $"WHERE minionsvillains.VillainId = @villainID",
                    connection
                );
                sql1.Parameters.AddWithValue("@villainID", villainID);

                var reader = sql1.ExecuteReader();
                int i = 1;
                bool hasNames = false;
                while (reader.Read())
                {
                    hasNames = true;
                    Console.WriteLine("{0}. {1}", i++, reader[0]);
                }
                if (!hasNames)
                {
                    Console.WriteLine($"No villain with ID {villainID} exists in the database.");
                }
            }
        }
    }
}
