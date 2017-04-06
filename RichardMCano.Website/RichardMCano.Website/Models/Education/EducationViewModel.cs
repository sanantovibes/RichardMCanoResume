using System;
using System.Collections.Generic;
using System.Web;
using RichardMCano.Domain.Models.Education;
using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Website.Models.Education
{
    public class EducationViewModel : ViewModel
    {
        public List<EducationItem> Educations { get; set; }
        public Applicant Applicant { get; set; }

        public EducationViewModel()
        {
            Educations = new List<EducationItem>();
            Applicant = new Applicant();
        }

    }
}