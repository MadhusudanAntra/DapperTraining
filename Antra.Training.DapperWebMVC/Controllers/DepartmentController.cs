using Microsoft.AspNetCore.Mvc;
using Training.ApplicationCore.RepositoryInterface;

namespace Antra.Training.DapperWebMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository repo)
        {
               departmentRepository = repo;
        }
        public IActionResult Index()
        {
            var result = departmentRepository.GetAll();
            return View(result);
        }
    }
}
