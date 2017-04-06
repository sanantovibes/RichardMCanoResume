using System;
using System.Collections.Generic;
using System.Web;
using RichardMCano.Domain.Models.Objective;
using RichardMCano.Domain.Models.TechnicalSkills;

namespace RichardMCano.Website.Models.TechnicalSkills
{
    public class TechnicalSkillsViewModel : ViewModel
    {
        public List<TechnicalSkillsItem> TechnicalSkillsList { get; set; }
        public Applicant Applicant { get; set; }

        public TechnicalSkillsViewModel()
        {
            TechnicalSkillsList = new List<TechnicalSkillsItem>();
            Applicant = new Applicant();
        }
    }
}