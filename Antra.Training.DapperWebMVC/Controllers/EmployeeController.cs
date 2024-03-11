using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training.ApplicationCore.Models;
using Training.ApplicationCore.RepositoryInterface;

namespace Antra.Training.DapperWebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;
        public EmployeeController(IEmployeeRepository repo, IDepartmentRepository drepo)
        {
            departmentRepository= drepo;
            employeeRepository = repo;
        }
        public IActionResult Index()
        {
            var result = employeeRepository.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Department = new SelectList(departmentRepository.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            employeeRepository.Insert(obj);
            return View();
        }
    }
}
