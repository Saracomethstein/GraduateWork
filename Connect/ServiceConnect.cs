using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Connection
{
    public class ServiceConnect : IServiceConnect
    {
        public const string filePath = @"C:\ProgramData\cursorposition.db";

        public static SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version = 3; New = True; Compress = True;");

        public bool CheckUser(string username, string password)
        {
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "SELECT * FROM users WHERE user_name = @username AND user_password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.ExecuteNonQuery();
            connection.Close();

            return count > 0;
        }
    }
}
