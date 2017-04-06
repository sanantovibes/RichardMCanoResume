using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RichardMCano.Domain.Models.Objective;
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

        public Applicant GetApplicant(string resumeGUID)
        {
            Applicant applicant = new Applicant();

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetApplicant";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@ResumeGUID", resumeGUID);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                applicant = null;
                return applicant;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    applicant = ReadApplicant(reader);
                }
            }

            con.Close();

            return applicant;
        }

        private Applicant ReadApplicant(SqlDataReader reader)
        {
            Applicant applicant = new Applicant();

            applicant.ApplicantName = reader["ApplicantName"].ToString();
            applicant.Cell = reader["Cell"].ToString();
            applicant.Home = reader["Home"].ToString();
            applicant.Email = reader["Email"].ToString();
            applicant.Address = reader["Address"].ToString();
            applicant.City = reader["City"].ToString();
            applicant.State = reader["State"].ToString();
            applicant.Zip = reader["Zip"].ToString();

            return applicant;
        }

        public List<TechnicalSkillsItem> GetTechnicalSkills()
        {
            List<TechnicalSkillsItem> technicalSkillsList = new List<TechnicalSkillsItem>();

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetTechnicalSkillsList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                technicalSkillsList = null;
                return technicalSkillsList;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var technicalSkills = ReadTechnicalSkills(reader);
                    technicalSkillsList.Add(technicalSkills);
                }
            }

            con.Close();

            return technicalSkillsList;
        }

        private TechnicalSkillsItem ReadTechnicalSkills(SqlDataReader reader)
        {
            TechnicalSkillsItem technicalSkill = new TechnicalSkillsItem();

            technicalSkill.TechnicalSkillsGUID = new Guid(reader["TechnicalSkillsGUID"].ToString());
            technicalSkill.TS_Description = reader["TS_Description"].ToString();

            return technicalSkill;
        }
    }
}