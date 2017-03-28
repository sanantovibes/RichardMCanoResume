using System;
using System.Collections.Generic;
using System.Web;
using RichardMCano.Domain.Models.Education;

namespace RichardMCano.Website.Models.Education
{
    public class EducationViewModel : ViewModel
    {
        public List<EducationItem> Educations = new List<EducationItem>();

        public EducationViewModel()
        {

        }

    }
}