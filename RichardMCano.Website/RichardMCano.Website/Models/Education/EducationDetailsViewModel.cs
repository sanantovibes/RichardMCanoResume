using System;
using System.Collections.Generic;
using System.Web;
using RichardMCano.Domain.Models.Education;
using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Website.Models.Education
{
    public class EducationDetailsViewModel : ViewModel
    {
        public EducationItem Education { get; set; }
        public List<MinorItem> MinorList { get; set; }
        public string Graduated { get; set; }
        public Applicant Applicant { get; set; }

        public EducationDetailsViewModel()
        {
            MinorList = new List<MinorItem>();
            Applicant = new Applicant();
            Education = new EducationItem();
        }
    }
}