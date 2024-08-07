using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Digests;

namespace Book.Entities
{
    public class Author
    {
        public int Id {get; set;}
        public string name {get; set;}
        public string lastName {get; set;}
        public string address {get; set;}
        public string country {get; set;}
        ICollection<Books> books {get; set;}
    }
}