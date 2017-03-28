using System;
using System.Collections.Generic;
using System.Web;
using RichardMCano.Domain.Models.Education;

namespace RichardMCano.Website.Models.Education
{
    public class EducationDetailsViewModel : ViewModel
    {
        public EducationItem Education = new EducationItem();
        public List<MinorItem> MinorList = new List<MinorItem>();
        public string Graduated { get; set; }

        public EducationDetailsViewModel()
        {
            
        }

    }
}