using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Entities
{
    public class Books
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public Categories Category { get; set; }
        public int CategoryId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
    }
}