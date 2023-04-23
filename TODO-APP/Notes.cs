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
        public string _name { get; set; }
        public Colors? _color { get; set; }
        public string _title { get; set; }
        public string _text { get; set; }

        public Notes(string name, string title, string text, Colors color = Colors.black)
        {
            _name = name;
            _color = color;
            _title = title;
            _text = text;
        }
    }
}
