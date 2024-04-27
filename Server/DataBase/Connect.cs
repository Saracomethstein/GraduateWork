using System;
using System.Data.SQLite;

namespace Server.DataBase
{
    internal class Connect
    {
        public const string filePath = @"C:\ProgramData\TestDataBase.db";

        public static SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version = 3; New = True; Compress = True;");

        #region Creating and connecting to the database
        public static void GetDbConnection()
        {
            try
            {
                connection.Open();

                InsertDataUsers(connection);

                connection.Close();
            }
            catch (SQLiteException ex)
            {
                ErrorWrite(ex.Message);
            }
        }

        static void InsertDataUsers(SQLiteConnection conn)
        {
            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT OR IGNORE INTO users" +
                "(user_name, user_password)" +
                "VALUES" +
                "('User', 'User');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT OR IGNORE INTO users" +
                "(user_name, user_password)" +
                "VALUES" +
                "('Admin', 'Admin');";
            cmd.ExecuteNonQuery();

            cmd.Dispose();
        }
        #endregion

        #region Console Settings
        public static void Write(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now}] [Info] {str}");
            Console.ResetColor();
        }

        public static void ErrorWrite(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now}] [Error:] {str}");
            Console.ResetColor();
        }
        #endregion
    }
}
