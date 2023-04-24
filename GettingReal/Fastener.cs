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
        public string Name { get; set; }
        public int Id { get; set; }

        public Fastener(string type, string name, int id) 
        {
            Type = type;
            Name = name;
            Id = id;
        }
    }
}
