using System;
using System.Data.SqlClient;

namespace SQLTask
{
    class Program
    {
        static void Main() {
            Console.WriteLine("Microsoft SQL Server:");
            Console.WriteLine(new string('-', 25));

            SqlConnection connection = new SqlConnection(
                "Server=.;Database=master;Integrated Security=true"
            );
            connection.Open();

            using (connection) {
                SqlCommand command1 = new SqlCommand(
                    "CREATE DATABASE MinionsOne", connection
                );
                command1.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand(
                    "USE MinionsOne", connection
                );
                command2.ExecuteNonQuery();

                SqlCommand command3 = new SqlCommand(
                    "CREATE TABLE minions (id INT, name VARCHAR(50), age INT)", connection
                );
                command3.ExecuteNonQuery();

                SqlCommand command4 = new SqlCommand(
                    "INSERT INTO minions (id, name, age) VALUES ('1', 'Kevin', '15');" +
                    "INSERT INTO minions (id, name, age) VALUES ('2', 'Bob', '22');" +
                    "INSERT INTO minions (id, name, age) VALUES ('3', 'Steward', '42');", connection
                );
                command4.ExecuteNonQuery();

                SqlCommand command5 = new SqlCommand(
                     "SELECT name, age FROM minions;", connection    
                );
                
                SqlDataReader reader = command5.ExecuteReader();
                while (reader.Read()) {
                    Console.WriteLine("Name: {0}, Age: {1}", reader[0], reader[1]);
                }
            }
        }
    }
}