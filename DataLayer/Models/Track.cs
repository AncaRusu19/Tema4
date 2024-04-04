using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Track
    {
        public Guid TrackId { get; set; }
        public string Title_track { get; set; }
        //vreau sa asociez cu clasa Vinyl (relatie one to many)
        
        public Guid VinylId { get; set; }
        public Vinyl Vinyl { get; set; }

        public Track(string title_track)
        {
            Title_track = title_track;
        }
    }
}
