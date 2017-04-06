using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Jobs;
using RichardMCano.Domain.Models.Objective;
using RichardMCano.Domain.Repositories.Jobs;
using RichardMCano.Website.Models.Jobs;

namespace RichardMCano.Website.Controllers
{
    public class JobsController : Controller
    {
        private readonly string _connectionString;

        public JobsController()
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

                JobsRepository _repository = new JobsRepository(_connectionString);

                Applicant applicant = _repository.GetApplicant(resumeGUID);
                List<Job> jobsList;
                var viewModel = new JobsViewModel();

                jobsList = _repository.GetJobs();

                viewModel.Applicant = applicant;
                viewModel.Jobs = jobsList;

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

                var viewModel = new JobsViewModel();
                JobsRepository _repository = new JobsRepository(_connectionString);

                Applicant applicant = _repository.GetApplicant(resumeGUID);
                JobDetails jobsDetail = _repository.GetJobDetails(id);
                var responsibilities = _repository.GetResponsibilities(id);

                viewModel.Title = "Richard M. Cano Resume";
                viewModel.Applicant = applicant;
                viewModel.JobDetails = jobsDetail;
                viewModel.Responsibilities = responsibilities;

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}