using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Education;
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

        public ActionResult Index()
        {
            try
            {
                var viewModel = new EducationViewModel();
                EducationRepository _repository = new EducationRepository(_connectionString);
                List<EducationItem> educationList = _repository.GetEducationList();

                viewModel.Title = "Richard M. Cano Resume";
                viewModel.Educations = educationList;

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Detail(Guid id)
        {
            try
            {
                var viewModel = new EducationDetailsViewModel();
                EducationRepository _repository = new EducationRepository(_connectionString);

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

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}