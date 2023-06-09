﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_APP
{
    internal class Render
    {

        public static void MainMenu()
        {
            int index = 1;
            List<string> menuList = new List<string>() { "Add a new note", "Update a note", "Delete a note", "Show Notes" };

            Console.WriteLine("--------- ToDo-App ---------");
            foreach (string i in menuList)
            {
                Console.WriteLine($"{index}. --- {i} ---.");
                index++;
            }
            Console.WriteLine("");
            Console.Write("Please choose an operation: ");
            int reply = Convert.ToInt32(Console.ReadLine());

            switch (reply)
            {
                case 1: AddNote();
                    break;
                case 2: UpdateNote();
                    break;
                case 3: DeleteNote();
                    break;
                case 4: DatabaseSQL.PrintData();
                    break;
                case 0:
                    break;
            }

        }

        public static void AddNote()
        {
            Console.Write("Please type in your title: ");
            string? noteTitle = Console.ReadLine();
            Console.Write("Type the text that you would like to add: ");
            string? noteText = Console.ReadLine();
            Console.Write("What color would you like: ");
            Colors noteColor = Enum.TryParse(Console.ReadLine(), true, out Colors color) ? color : Colors.black;
            Console.Write("Name of the author: ");
            string? noteAuthor = Console.ReadLine();
            DatabaseSQL.InsertNewNote(new Notes(noteAuthor, noteTitle, noteText, noteColor));

        }

        public static void UpdateNote()
        {
            Console.Write("Which one would you like to update: ");
            string? noteAuthor = Console.ReadLine();
            DatabaseSQL.SelectSpecificID(noteAuthor);
            Console.Write("Please choose note index to update: ");
            string? noteIndex = Console.ReadLine();
            Console.Write("Please type in the new updated text: ");
            string? noteUpdate = Console.ReadLine();
            DatabaseSQL.UpdateNote(noteUpdate, noteIndex);
            
        }

        public static void DeleteNote()
        {
            Console.Write($"Which note would you like to delete: ");
            string? reply = Convert.ToString(Console.ReadLine());
            DatabaseSQL.DeleteNote(reply);
        }



    }
}
