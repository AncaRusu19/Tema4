using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Producer
    {
        public Guid ProducerId { get; set; }
        public string ProducerName { get; set; }

        public List<Author> Authors { get; set; } 
        public Producer(string producer_name)
        {
            ProducerName = producer_name;
        }
    }
}
