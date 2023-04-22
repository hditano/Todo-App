using System;
using System.Data.SQLite;

namespace TODO_APP
{
    internal class DatabaseSQL
    {
        public SQLiteConnection myConnection;

        public DatabaseSQL()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3")) SQLiteConnection.CreateFile("database.sqlite3");
            Console.WriteLine("Database Connection Done");
        }

        private void InsertNewNote(string title, string text)
        {
            string query = $"INSERT INTO notes (title, text) VALUES (@title, @text)";
            using (SQLiteCommand cmd = new SQLiteCommand(query, myConnection)
            {
                return
            }
        }

        public void InsertData()
        {
            string query = "INSERT INTO user (name) VALUES (@name)";
            SQLiteCommand cmd = new SQLiteCommand(query, myConnection);
            myConnection.Open();
            cmd.Parameters.AddWithValue("@name", "Hernan");
            var data = cmd.ExecuteNonQuery();
            Console.WriteLine("Rows Added: {0}", data);
            myConnection.Close();
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
