using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class ResourceClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public bool Rented { get; set; }


        public ResourceClass (int id, string name, string type, int amount, bool rented)
        {
            Id = id;
            Name = name;
            Type = type;
            Amount = amount;
            Rented = rented;
        }
    }
}
