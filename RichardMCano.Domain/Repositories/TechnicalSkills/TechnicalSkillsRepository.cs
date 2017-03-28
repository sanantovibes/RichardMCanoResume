using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RichardMCano.Domain.Models.TechnicalSkills;

namespace RichardMCano.Domain.Repositories.TechnicalSkills
{
    public class TechnicalSkillsRepository
    {
        private readonly string _connectionString;
        public TechnicalSkillsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<TechnicalSkillsItem> GetTechnicalSkills()
        {
            List<TechnicalSkillsItem> technicalSkillsList = new List<TechnicalSkillsItem>();

            return technicalSkillsList;
        }
    }
}