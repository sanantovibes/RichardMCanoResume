using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.TechnicalSkills;
using RichardMCano.Domain.Repositories.TechnicalSkills;
using RichardMCano.Website.Models.TechnicalSkills;

namespace RichardMCano.Website.Controllers
{
    public class TechnicalSkillsController : Controller
    {
        private readonly string _connectionString;

        public TechnicalSkillsController()
        {
            _connectionString = Settings.GetConnectionString();
        }

        public ActionResult Index()
        {
            TechnicalSkillsViewModel viewModel = new TechnicalSkillsViewModel();
            TechnicalSkillsRepository _repository = new TechnicalSkillsRepository(_connectionString);

            List<TechnicalSkillsItem> technicalSkillsList = _repository.GetTechnicalSkills();

            viewModel.TechnicalSkillsList = technicalSkillsList;

            return View(viewModel);
        }
    }
}