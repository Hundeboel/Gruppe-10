using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public partial class Fastener
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public Fastener(int id, string name, string type, string description,int amount) 
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            Amount = amount;
        }
    }
}
