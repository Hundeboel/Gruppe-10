﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public partial class Project
    {
        public string Name { get; set; }
        public bool Finished { get; set; }
        public TimeSpan Timeframe { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Project(string name, bool finished, TimeSpan timeframe)
        {
            Name = name;
            Finished = finished;
            Timeframe = timeframe;
        }
    }
}
