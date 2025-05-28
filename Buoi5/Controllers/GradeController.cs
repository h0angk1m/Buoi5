using Buoi5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi5.Controllers
{
    public class GradeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Grade> listGrade = _context.Grades.ToList();

            return View(listGrade);
        }
    }
}
