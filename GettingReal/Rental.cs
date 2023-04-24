using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Rental
    {
        public Project project { get; set; }
        public Resource resource { get; set; }
        public Employee employee { get; set; }
        public Calendar timeframe { get; set; }
    }
}
