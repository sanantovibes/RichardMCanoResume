using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichardMCano.Domain.Repositories.Home
{
    public class HomeRepository
    {
        private readonly string _connectionString;
        public HomeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
