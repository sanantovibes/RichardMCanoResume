using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Objective;
using RichardMCano.Domain.Repositories;
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
                Repository _repositoryMain = new Repository(_connectionString);
                ContactRepository _repository = new ContactRepository(_connectionString);

                Applicant applicant = _repositoryMain.GetApplicant(resumeGUID);

                viewModel.Applicant = applicant;

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}