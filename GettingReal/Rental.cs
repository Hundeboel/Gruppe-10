using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public partial class Rental
    {
        /// <summary>
        /// Ændret til strings (fra Project, Resource og Employee-typer) 
        /// </summary>
        public string Project { get; set; }
        public string Resource { get; set; }
        public string Rentee { get; set; }
        public TimeSpan Timeframe { get; set; }
    }
}
