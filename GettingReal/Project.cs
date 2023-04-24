using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Project
    {
        public string Name { get; set; }
        public bool Finished { get; set; }

        public Project(string name, bool finished)
        {
            Name = name;
            Finished = finished;
        }
    }
}
