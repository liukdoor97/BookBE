using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models.AuthorModel
{
    // Modello di input di Author
    public class AuthorModel
    {
        public string name {get; set;}
        public string lastName {get; set;}
        public string address {get; set;}
        public string country {get; set;}
    }
}