using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class RentalClass
    {
        public ProjectClass Project { get; set; }
        public ResourceClass Resource { get; set; }
        public Employee Rentee { get; set; }
        public TimeSpan Timeframe { get; set; }
    }
}
