using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Website.Models.Contact
{
    public class ContactViewModel : ViewModel
    {
        public Applicant Applicant { get; set; }

        public ContactViewModel()
        {
            Applicant = new Applicant();
        }
    }
}