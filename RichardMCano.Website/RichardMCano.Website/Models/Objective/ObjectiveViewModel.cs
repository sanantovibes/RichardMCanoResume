using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Website.Models.Objective
{
    public class ObjectiveViewModel : ViewModel
    {
        public List<ObjectiveItem> Objectives { get; set; }
        public Applicant Applicant { get; set; }

        public ObjectiveViewModel ()
        {
            Objectives = new List<ObjectiveItem>();
            Applicant = new Applicant();
        }
    }
}