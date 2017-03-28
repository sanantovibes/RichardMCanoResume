﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RichardMCano.Domain.Models.Jobs;

namespace RichardMCano.Website.Models.Jobs
{
    public class JobsViewModel : ViewModel
    {
        public List<Job> Jobs { get; set; }
        public JobDetails JobDetails { get; set; }
        public List<Responsibilities> Responsibilities { get; set; }

        public JobsViewModel()
        {

        }
    }
}