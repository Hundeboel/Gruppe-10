using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Resource
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public bool Rented { get; set; }
        public int Id { get; set; }

        public Resource (string type, int amount, bool rented, int id)
        {
            Type = type;
            Amount = amount;
            Rented = rented;
            Id = id;
        }
    }
}
