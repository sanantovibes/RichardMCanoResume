using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Objective;
using RichardMCano.Domain.Repositories.Contact;
using RichardMCano.Website.Models.Contact;

namespace RichardMCano.Website.Controllers
{
    public class ContactController : Controller
    {
        private readonly string _connectionString;

        public ContactController()
        {
            _connectionString = Settings.GetConnectionString();
        }

        public ActionResult Index(string resumeGUID)
        {
            try
            {
                if (resumeGUID == null || string.IsNullOrWhiteSpace(resumeGUID))
                {
                    resumeGUID = "6257B7B5-C4D0-4D00-ACB4-350A95861B7F";
                }

                var viewModel = new ContactViewModel();
                ContactRepository _repository = new ContactRepository(_connectionString);

                Applicant applicant = _repository.GetApplicant(resumeGUID);

                viewModel.Applicant = _repository.GetApplicant(resumeGUID);

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}