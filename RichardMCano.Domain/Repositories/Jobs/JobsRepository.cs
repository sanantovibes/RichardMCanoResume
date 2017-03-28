using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RichardMCano.Domain.Models.Jobs;

namespace RichardMCano.Domain.Repositories.Jobs
{
    public class JobsRepository
    {
        private readonly string _connectionString;
        public JobsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Job> GetJobs()
        {
            var jobsList = new List<Job>();

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetJobs";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            } else
            {
                jobsList = null;
                return jobsList;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var job = ReadJobs(reader);
                    jobsList.Add(job);
                }
            }

            con.Close();

            return jobsList;
        }

        private Job ReadJobs(SqlDataReader reader)
        {
            var job = new Job();

            job.JobGUID = new Guid(reader["JobGUID"].ToString());
            job.JobName = reader["JobName"].ToString();
            job.MonthStart = reader["MonthStart"].ToString();
            job.YearStart = reader["YearStart"].ToString();
            job.MonthEnd = reader["MonthEnd"].ToString();
            job.YearEnd = reader["YearEnd"].ToString();

            return job;
        }

        public JobDetails GetJobDetails(Guid jobsGUID)
        {
            JobDetails jobDetails = new JobDetails();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetJobDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@JobsGUID", jobsGUID);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            } else
            {
                jobDetails = null;
                return jobDetails;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    jobDetails = ReadJobDetails(reader);
                }
            }

            con.Close();

            return jobDetails;
        }

        private JobDetails ReadJobDetails (SqlDataReader reader)
        {
            JobDetails jobDetails = new JobDetails();

            jobDetails.JobsGUID = new Guid(reader["JobsGUID"].ToString());
            jobDetails.JobName = reader["JobName"].ToString();
            jobDetails.YearStart = reader["YearStart"].ToString();
            jobDetails.YearEnd = reader["YearEnd"].ToString();
            jobDetails.MonthStart = reader["MonthStart"].ToString();
            jobDetails.MonthEnd = reader["MonthEnd"].ToString();
            jobDetails.Description = reader["Description"].ToString();
            jobDetails.JobTitle = reader["JobTitle"].ToString();

            return jobDetails;
        }

        public List<Responsibilities> GetResponsibilities(Guid jobsGUID)
        {
            List<Responsibilities> responsibilities = new List<Responsibilities>();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetJobResponsibilities";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@JobsGUID", jobsGUID);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                responsibilities = null;
                return responsibilities;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var responsibility = ReadResponsibilities(reader);
                    responsibilities.Add(responsibility);
                }
            }

            con.Close();

            return responsibilities;
        }

        private Responsibilities ReadResponsibilities(SqlDataReader reader)
        {
            Responsibilities responsibilities = new Responsibilities();

            responsibilities.R_Description = reader["R_Description"].ToString();

            return responsibilities;
        }

        public List<JobTitle> GetJobTitles(Guid jobsGUID)
        {
            List<JobTitle> jobTitles = new List<JobTitle>();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetJobTitles";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@JobsGUID", jobsGUID);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                jobTitles = null;

                return jobTitles;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var jobTitle = ReadJobTitle(reader);
                    jobTitles.Add(jobTitle);
                }
            }

            con.Close();

            return jobTitles;
        }

        private JobTitle ReadJobTitle(SqlDataReader reader)
        {
            JobTitle jobTitle = new JobTitle();

            jobTitle.JobTitleName = reader["JobTitleName"].ToString();

            return jobTitle;
        }
    }
}
