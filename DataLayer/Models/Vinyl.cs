using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Vinyl
    {
        public Guid VinylId { get; set; }
        public string Title { get; set; }
        //public string Singer { get; set; }
        public int Age { get; set; }
        public string Best_Song { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } 
        public List<Track> Tracks { get; set; } 


        public Vinyl(string title,  int age, string bsong)
        {
            Title = title;
            Age = age;
            Best_Song = bsong;
        }
    }
}
