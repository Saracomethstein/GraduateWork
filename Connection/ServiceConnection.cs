﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Connection
{
    public class ServiceConnection : IServiceConnection
    {
        public const string filePath = @"C:\ProgramData\cursorposition.db";

        public static SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version = 3; New = True; Compress = True;");

        public void AddNewUserInDB(string username, string password)
        {
            throw new NotImplementedException();
        }

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

        public bool CheckUserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
