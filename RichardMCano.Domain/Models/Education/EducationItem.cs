using System;
using System.Collections.Generic;

namespace RichardMCano.Domain.Models.Education
{
    public class EducationItem
    {
        public Guid EducationGUID { get; set; }
        public string SchoolName { get; set; }
        public string DegreeName { get; set; }
        public int EducationHours { get; set; }
        public bool IsGraduated { get; set; }
        public string GraduatedDate { get; set; }
        public string MinorName { get; set; }
        public string ConcentrationName { get; set; }
    }
}
