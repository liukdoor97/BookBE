using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Models.BookModel
{
    // Modello di input di Book
    public class BookModel
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public int categoryId { get; set; }
        public int authorId { get; set; }
        public int publisherId { get; set; }
    }
}