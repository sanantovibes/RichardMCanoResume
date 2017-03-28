using System;
using System.Configuration;
using RichardMCano.Domain;

namespace RichardMCano.Website
{
    public class Settings : IRichardMCanoSettings
    {
        public string ConnectionString { get; set; }

        public Settings()
        {
            ConnectionString = GetConnectionString();
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RichardMCano"].ConnectionString;
        }
    }
}