using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RichardMCano.Website.Models
{
    public class ViewModel
    {
        public string Title { get; set; }
        public string Year { get; set; }

        public ViewModel()
        {
            Title = "Richard M. Cano Rèsumè";
            Year = DateTime.Now.Year.ToString();
        }
    }
}