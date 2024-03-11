using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ApplicationCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentId { get; set; }
        public string EmailId { get; set; }

        public Department Department { get; set; }
    }
}
