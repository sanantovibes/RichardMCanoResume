using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RichardMCano.Domain.Models.Objective;

namespace RichardMCano.Domain.Repositories.Contact
{
    public class ContactRepository
    {
        private readonly string _connectionString;
        public ContactRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
