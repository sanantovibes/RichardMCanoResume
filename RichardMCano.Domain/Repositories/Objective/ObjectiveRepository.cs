using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Domain.Repositories.Home
{
    public class ObjectiveRepository
    {
        private readonly string _connectionString;
        public ObjectiveRepository(string connectionString)
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

        public List<ObjectiveItem> GetObjectives(string resumeGUID)
        {
            List<ObjectiveItem> objectivesList = new List<ObjectiveItem>();

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetObjectives";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@ResumeGUID", resumeGUID);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                objectivesList = null;
                return objectivesList;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var objective = ReadObjectives(reader);
                    objectivesList.Add(objective);
                }
            }

            con.Close();

            return objectivesList;
        }

        private ObjectiveItem ReadObjectives(SqlDataReader reader)
        {
            var objective = new ObjectiveItem();

            objective.ObjectiveDescription = reader["ObjectiveDescription"].ToString();

            return objective;
        }
    }
}
