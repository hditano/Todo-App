using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_APP
{
    internal class DataManager
    {

        public DatabaseSQL AccessDataBase { get; set; }
        
        public void AddNewNote()
        {
            AccessDataBase.InsertData(string title, string text);
        }


    }
}
