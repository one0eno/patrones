using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterASP.Configuration
{
    public class MyConfig
    {
        public string PathLog { get; set; }

        public decimal LocalPercentage { get; set; }

        public decimal ForeignPercentage { get; set; }

        public decimal Extra { get; set; }
    }
}
