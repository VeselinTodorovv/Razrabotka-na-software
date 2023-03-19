using System;
using Microsoft.Data.SqlClient;

namespace NonSQLInjection {
    static class Program {
        static void Main() {
            bool normalLogin = IsPasswordValid("peter", "qwerty123"); //true
            Console.WriteLine(normalLogin);

            bool sqlInjectedLogin = IsPasswordValid("' or 1=1 --", "qwerty123"); //true
            Console.WriteLine(sqlInjectedLogin);

            bool sqlInjectedLogin2 = IsPasswordValid("' or 1=1 --", "' or 1=1 --");
            Console.WriteLine(sqlInjectedLogin2);

            bool evilHackerCreatesNewUser = IsPasswordValid("' INSERT INTO Users VALUES('hacker', '') --", 
                "qwerty123");
            Console.WriteLine(evilHackerCreatesNewUser);

            bool evilHackerDropDatabase = IsPasswordValid("' DROP TABLE Test; --", "qwerty123");
            Console.WriteLine(evilHackerDropDatabase);
        }

        static bool IsPasswordValid(string username, string password) {
            string connectionString = "Data Source=.;Database=Test;Integrated Security=true;";
            SqlConnection connection = new(connectionString);
            connection.Open();

            string sql = "SELECT COUNT(*) FROM Users " +
                         "WHERE Username = @username AND " +
                         "PasswordHash = @password";
            SqlCommand cmd1 = new(sql, connection);
            cmd1.Parameters.AddWithValue("@username", username);
            cmd1.Parameters.AddWithValue("@password", password);

            cmd1.ExecuteNonQuery();

            int matchedUsersCount = (int) cmd1.ExecuteScalar();
            connection.Close();

            return matchedUsersCount > 0;
        }
    }
}