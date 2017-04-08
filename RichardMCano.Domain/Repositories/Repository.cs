using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Domain.Repositories
{
    public class Repository
    {
        private readonly string _connectionString;
        public Repository(string connectionString)
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
    }
}
