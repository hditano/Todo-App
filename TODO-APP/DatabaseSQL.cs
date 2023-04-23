using System;
using System.Data.SQLite;
using System.Data.SqlTypes;
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

        public static void PrintData()
        {
            string query = "SELECT user.name AS author, notes.title AS title FROM notes LEFT OUTER JOIN user ON user.id=notes.userid WHERE user.id=notes.userid";
            SQLiteCommand cmd = new SQLiteCommand(query, GetInstance().myConnection);
            GetInstance().myConnection.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Id | Author | Title");
            while(reader.Read())
            {
                Console.WriteLine($"{reader["id"]} | {reader["author"]} | {reader["title"]}");
            }
            GetInstance().myConnection.Close();
        }

        public static void PrintSpecificData(string name)
        {
            string query = $"SELECT user.name AS author, notes.title AS title, notes.text AS text, notes.color AS color FROM notes LEFT OUTER JOIN user ON user.id=notes.userid WHERE author=@author";
            SQLiteCommand cmd = new SQLiteCommand(query, GetInstance().myConnection);
            GetInstance().myConnection.Open();
            cmd.Parameters.AddWithValue("@author", name);
            SQLiteDataReader reader =  cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["author"]} {reader["title"]} {reader["text"]} {reader["color"]}");
            }
            GetInstance().myConnection.Close();
            
        }

        public static void DeleteNote(string noteIndex)
        {
            string query = $"DELETE FROM notes WHERE id={noteIndex}";
            SQLiteCommand cmd = new SQLiteCommand(query, GetInstance().myConnection);
            GetInstance().myConnection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Note {noteIndex} deleted");
            GetInstance().myConnection.Close();
        }

    }
}
