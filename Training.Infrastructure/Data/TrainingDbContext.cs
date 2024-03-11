using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Training.Infrastructure.Data
{
    public class TrainingDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public TrainingDbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
           connectionString= configuration.GetConnectionString("TrainingDb");
        }

        public IDbConnection GetDbConnection()
        { 
          return new SqlConnection(connectionString);
        }


    }
}
