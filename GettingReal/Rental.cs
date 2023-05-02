using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public partial class Rental
    {
        public Project Project { get; set; }
        public Resource Resource { get; set; }
        public Employee Rentee { get; set; }
        public TimeSpan Timeframe { get; set; }
    }
}
