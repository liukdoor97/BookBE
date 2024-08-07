using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string name { get; set; }
        ICollection<Books> books {get; set;}

    }
}