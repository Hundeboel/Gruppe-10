using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Fastener
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }

        public Fastener(string type, string description,int amount, int id) 
        {
            Type = type;
            Description = description;
            Amount = amount;
            Id = id;
        }
    }
}
