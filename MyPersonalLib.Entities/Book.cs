using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool? Status { get; set; }
        public byte? Rate { get; set; }
    }
}
