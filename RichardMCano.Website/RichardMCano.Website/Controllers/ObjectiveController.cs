using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Objective;
using RichardMCano.Domain.Repositories;
using RichardMCano.Domain.Repositories.Home;
using RichardMCano.Website.Models.Objective;

namespace RichardMCano.Website.Controllers
{
    public class ObjectiveController : Controller
    {
        private readonly string _connectionString;

        public ObjectiveController()
        {
            _connectionString = Settings.GetConnectionString();
        }

        public ActionResult Index(string resumeGUID)
        {
            try
            {
                if (resumeGUID == null ||string.IsNullOrWhiteSpace(resumeGUID))
                {
                    resumeGUID = "6257B7B5-C4D0-4D00-ACB4-350A95861B7F";
                }
                    var viewModel = new ObjectiveViewModel();
                Repository _repositoryMain = new Repository(_connectionString);
                ObjectiveRepository _repository = new ObjectiveRepository(_connectionString);

                Applicant applicant = _repositoryMain.GetApplicant(resumeGUID);
                List<ObjectiveItem> objectivesList = _repository.GetObjectives(resumeGUID);

                viewModel.Objectives = objectivesList;
                viewModel.Applicant = applicant;

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}