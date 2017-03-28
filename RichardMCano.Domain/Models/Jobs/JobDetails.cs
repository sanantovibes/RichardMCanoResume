using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichardMCano.Domain.Models.Jobs
{
    public class JobDetails
    {
        public Guid JobsGUID { get; set; }
        public string JobName { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
        public string MonthStart { get; set; }
        public string MonthEnd { get; set; }
        public string Description { get; set; }
        public string JobTitle { get; set; }
    }
}
