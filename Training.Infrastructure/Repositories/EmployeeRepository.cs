using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.ApplicationCore.Models;
using Training.ApplicationCore.RepositoryInterface;
using Training.Infrastructure.Data;
using Dapper;
using System.Data;

namespace Training.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly TrainingDbContext trainingDbContext;
        public EmployeeRepository(TrainingDbContext dbContext)
        {
            trainingDbContext = dbContext;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            var conn = trainingDbContext.GetDbConnection();
            return conn.Query<Employee, Department, Employee>("sp_employeedetails", (e, d) =>
            {
                e.Department = d;
                return e;
            });
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee entity)
        {
            var conn = trainingDbContext.GetDbConnection();
            return conn.Execute("sp_InsertEmployee", new { Name = entity.Name, Salary = entity.Salary, DepartmentId = entity.DepartmentId, EmailId = entity.EmailId }, commandType: CommandType.StoredProcedure);
        }

        public int Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
