﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Domain.Models.Objective;
using RichardMCano.Domain.Models.TechnicalSkills;
using RichardMCano.Domain.Repositories;
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

        public ActionResult Index(string resumeGUID)
        {
            try
            {
                if (resumeGUID == null || string.IsNullOrWhiteSpace(resumeGUID))
                {
                    resumeGUID = "6257B7B5-C4D0-4D00-ACB4-350A95861B7F";
                }

                TechnicalSkillsViewModel viewModel = new TechnicalSkillsViewModel();
                Repository _repositoryMain = new Repository(_connectionString);
                TechnicalSkillsRepository _repository = new TechnicalSkillsRepository(_connectionString);

                Applicant applicant = _repositoryMain.GetApplicant(resumeGUID);
                List<TechnicalSkillsItem> technicalSkillsList = _repository.GetTechnicalSkills();

                viewModel.Applicant = applicant;
                viewModel.TechnicalSkillsList = technicalSkillsList;

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}