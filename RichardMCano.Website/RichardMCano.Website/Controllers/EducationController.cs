using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Education;
using RichardMCano.Domain.Models.Objective;
using RichardMCano.Domain.Repositories.Education;
using RichardMCano.Website.Models.Education;

namespace RichardMCano.Website.Controllers
{
    public class EducationController : Controller
    {
        private readonly string _connectionString;

        public EducationController()
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

                var viewModel = new EducationViewModel();
                EducationRepository _repository = new EducationRepository(_connectionString);
                List<EducationItem> educationList = _repository.GetEducationList();
                Applicant applicant = _repository.GetApplicant(resumeGUID);

                viewModel.Educations = educationList;

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Detail(Guid id, string resumeGUID)
        {
            try
            {
                if (resumeGUID == null || string.IsNullOrWhiteSpace(resumeGUID))
                {
                    resumeGUID = "6257B7B5-C4D0-4D00-ACB4-350A95861B7F";
                }

                var viewModel = new EducationDetailsViewModel();
                EducationRepository _repository = new EducationRepository(_connectionString);

                Applicant applicant = _repository.GetApplicant(resumeGUID);
                EducationItem education = _repository.GetEducationDetails(id);
                List<MinorItem> minorList = _repository.GetMinorList(id);

                if (education.IsGraduated == true)
                {
                    viewModel.Graduated = "Graduated";
                } else
                {
                    viewModel.Graduated = "Did not Graduate";
                }

                viewModel.Title = "Richard M. Cano Resume";
                viewModel.Education = education;
                viewModel.MinorList = minorList;
                viewModel.Applicant = applicant;

                return View(viewModel);
            }
            catch (InvalidCastException e)
            {
                throw (e);
                //return View("Error");
            }
        }
    }
}