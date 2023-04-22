using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_APP
{
    internal class Render
    {
        public static void MainMenu()
        {
            Console.WriteLine("------ ToDo-App -------");
            Console.WriteLine("1 .--- Add a new note ------");
            Console.Write("Please choose an operation: ");
            int reply = Convert.ToInt32(Console.ReadLine());

            switch (reply)
            {
                case 1: AddNote();
                    break;
                case 0:
                    break;
            }

        }

        private static void AddNote()
        {
            Console.Write("Please type in your title: ");
            string noteTitle = Console.ReadLine();
            Console.Write("Type the text that you would like to add: ");
            string noteText = Console.ReadLine();
            
        }
    }
}
