using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_APP
{
    internal class Notes
    {
        public int Id { get; set; }
        public Colors Color { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Notes(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
