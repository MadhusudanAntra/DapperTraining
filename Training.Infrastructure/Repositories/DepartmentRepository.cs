using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Training.ApplicationCore.RepositoryInterface;
using Training.Infrastructure.Data;
using Training.ApplicationCore.Models;

namespace Training.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TrainingDbContext trainingDbContext;

        public DepartmentRepository(TrainingDbContext _trainingDbContext)
        {
            trainingDbContext = _trainingDbContext;
        }

        public int Delete(int id)
        {
            var conn = trainingDbContext.GetDbConnection();
            return conn.Execute("Delete from Departments where id=@id", id);

        }

        public IEnumerable<Department> GetAll()
        {
            var conn = trainingDbContext.GetDbConnection();
            return conn.Query<Department>("Select Id, Name, Location from Departments");
        }

        public Department GetById(int id)
        {
            var conn = trainingDbContext.GetDbConnection();
            return conn.QueryFirstOrDefault<Department>("Select Id,Name, Location from Departments where id=@id", id);
        }

        public int Insert(Department entity)
        {

            var conn = trainingDbContext.GetDbConnection();

            return conn.Execute("Insert into Departments values (@Name,@Location)", entity);
        }



        public int Update(Department entity)
        {
            var conn = trainingDbContext.GetDbConnection();
            return conn.Execute("Update departments set Name=@Name, Location=@Location where id=@Id", entity);
        }

    }
}
