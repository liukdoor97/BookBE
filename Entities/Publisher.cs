using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string address {get; set;}
        public string country {get; set;}
        ICollection<Books> books { get; set; }
    }
}