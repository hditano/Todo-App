using System;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace TODO_APP
{
    internal class DatabaseSQL
    {
        private static DatabaseSQL? _instance;
        public SQLiteConnection myConnection;

        public DatabaseSQL()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3")) SQLiteConnection.CreateFile("database.sqlite3");
            Console.WriteLine("Database Connection Done");
        }

        public static DatabaseSQL GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DatabaseSQL();
            }

            return _instance;
        }

        public static void InsertNewNote(Notes note)
        {
            string query = $"INSERT INTO notes (userid, color,  title, text) VALUES ((SELECT id FROM user WHERE name = @userid),@color, @title, @text)";
            SQLiteCommand cmd = new SQLiteCommand(query, GetInstance().myConnection);
            GetInstance().myConnection.Open();
            cmd.Parameters.AddWithValue("@userid", $"{note._name}");
            cmd.Parameters.AddWithValue("@title", $"{note._title}");
            cmd.Parameters.AddWithValue("@text", $"{note._text}");
            cmd.Parameters.AddWithValue("@color", $"{note._color}");
            cmd.ExecuteNonQuery();
            GetInstance().myConnection.Close();
        }

        public void PrintData()
        {
            string query = "SELECT name FROM user";
            SQLiteCommand cmd = new SQLiteCommand(query, myConnection);
            myConnection.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"{reader["name"]}");
            }
            myConnection.Close();
        }

        public void CheckSpecificData(int text)
        {
            string query = "SELECT id, name FROM user WHERE ID = @ID ";
            SQLiteCommand cmd = new SQLiteCommand(query, myConnection);
            Console.WriteLine("Type your id");
            int reply = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@ID", reply);
            myConnection.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"{reader["name"]}");
            }
        }
    }
}
