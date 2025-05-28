using Buoi5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi5.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.Include(s => s.Grade).ToListAsync();
            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Students.Include(s => s.Grade).FirstOrDefaultAsync(s => s.StudentId == id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewBag.GradeId = new SelectList(_context.Grades.ToList(), "GradeId", "GradeName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Khi có lỗi nhập liệu, cần nạp lại SelectList
            ViewBag.GradeId = new SelectList(_context.Grades.ToList(), "GradeId", "GradeName", student.GradeId);
            return View(student);
        }



        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            ViewBag.GradeId = new SelectList(_context.Grades.ToList(), "GradeId", "GradeName", student.GradeId);
            return View(student);
        }


        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.GradeId = new SelectList(_context.Grades.ToList(), "GradeId", "GradeName", student.GradeId);
            return View(student);
        }


        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.Include(s => s.Grade).FirstOrDefaultAsync(s => s.StudentId == id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
