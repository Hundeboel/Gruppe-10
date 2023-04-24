using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Calendar
    {  
        public DateTime Date { get; set; }
        public DateTime Timestamp { get; set; }

        public Calendar(DateTime date, DateTime timestamp)
        {
            Date = date;
            Timestamp = timestamp;
        }
    }
}
