using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Jobs;
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

        public ActionResult Index()
        {
            try
            {
                JobsRepository _repository = new JobsRepository(_connectionString);

                List<Job> jobsList;
                var viewModel = new JobsViewModel();

                jobsList = _repository.GetJobs();

                viewModel.Jobs = jobsList;
                viewModel.Title = "Richard M. Cano Resume";

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
                var viewModel = new JobsViewModel();
                JobsRepository _repository = new JobsRepository(_connectionString);

                var jobsDetail = _repository.GetJobDetails(id);
                var responsibilities = _repository.GetResponsibilities(id);

                viewModel.Title = "Richard M. Cano Resume";
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