using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPersonalLib.MvcUI.Models
{
    public class BookListViewModel
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public byte? Rate { get; set; }
    }
}
