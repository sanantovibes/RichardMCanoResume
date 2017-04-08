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
