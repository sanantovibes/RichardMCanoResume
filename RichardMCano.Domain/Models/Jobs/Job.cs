using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichardMCano.Domain.Models.Jobs
{
    public class Job
    {
        public Guid JobGUID { get; set; }
        public string JobName { get; set; }
        public string MonthStart { get; set; }
        public string MonthEnd { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
    }
}
