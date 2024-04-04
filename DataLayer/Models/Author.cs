using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }

        public Guid VinylId { get; set; }
        public Vinyl Vinyl { get; set; } 
        public List<Producer> Producers { get; set; } 

        public Author(string name)
        {
            Name = name;
        }
    }
}
