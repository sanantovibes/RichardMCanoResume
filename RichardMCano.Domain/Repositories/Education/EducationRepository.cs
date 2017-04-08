using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RichardMCano.Domain.Models.Education;
using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Domain.Repositories.Education
{
    public class EducationRepository
    {
        private readonly string _connectionString;

        public EducationRepository (string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<EducationItem> GetEducationList ()
        {
            List<EducationItem> educationList = new List<EducationItem>();

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetEducationList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                educationList = null;
                return educationList;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var education = ReadEducations(reader);
                    educationList.Add(education);
                }
            }

            con.Close();
            
            return educationList;
        }

        private EducationItem ReadEducations (SqlDataReader reader)
        {
            EducationItem education = new EducationItem();

            education.EducationGUID = new Guid(reader["EducationGUID"].ToString());
            education.SchoolName = reader["SchoolName"].ToString();
            education.DegreeName = reader["DegreeName"].ToString();
            education.IsGraduated = (bool)(reader["IsGraduated"]);
            education.EducationHours = (int)(reader["EducationHours"]);
            education.GraduatedDate = reader["GraduatedDate"].ToString();
            //education.MinorName = reader["MinorName"].ToString();
            //education.ConcentrationName = reader["ConcentrationName"].ToString();

            return education;
        }

        public EducationItem GetEducationDetails(string resumeGUID, Guid educationGUID)
        {
            EducationItem education = new EducationItem();

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetEducationDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@ResumeGUID", resumeGUID);
            cmd.Parameters.AddWithValue("@EducationGUID", educationGUID);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                education = null;
                return education;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    education = ReadEducation(reader);
                }
            }

            con.Close();

            return education;
        }

        private EducationItem ReadEducation(SqlDataReader reader)
        {
            EducationItem education = new EducationItem();

            education.EducationGUID = new Guid(reader["EducationGUID"].ToString());
            education.SchoolName = reader["SchoolName"].ToString();
            education.DegreeName = reader["DegreeName"].ToString();
            education.IsGraduated = (bool)(reader["IsGraduated"]);
            education.EducationHours = (int)(reader["EducationHours"]);
            education.GraduatedDate = reader["GraduatedDate"].ToString();
            education.ConcentrationName = reader["ConcentrationName"].ToString();

            return education;
        }

        public List<MinorItem> GetMinorList(Guid educationGUID)
        {
            List<MinorItem> minorList = new List<MinorItem>();

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Resume_GetEducationMinors";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@EducationGUID", educationGUID);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                minorList = null;
                return minorList;
            }

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var minor = ReadMinor(reader);
                    minorList.Add(minor);
                }
            }

            con.Close();

            return minorList;
        }

        private MinorItem ReadMinor(SqlDataReader reader)
        {
            MinorItem minor = new MinorItem();

            minor.MinorName = reader["MinorName"].ToString();

            return minor;
        }
    }
}
