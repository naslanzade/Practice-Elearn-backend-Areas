using Elearn.Data;
using Elearn.Models;
using Elearn.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Controllers
{
    public class CoursesController : Controller
    {


        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            List<Course> courses = await _context.Courses.Include(m => m.Images).Include(m=>m.Author).Where(m => !m.SoftDeleted).Take(3).ToListAsync();
            Course course = await _context.Courses.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Author).Take(1).OrderByDescending(m => m.CreatedDate).FirstOrDefaultAsync();
            int count = await _context.Courses.Include(m => m.Images).Where(m => !m.SoftDeleted).CountAsync();
            ViewBag.count = count;

            CourseVM courseVM = new()            {               
                Course = course,
                Courses =courses
            };
            return View(courseVM);
        }


        [HttpGet]
        public async Task<IActionResult> ShowMoreOrLess(int skip)
        {
            List<Course> courses = await _context.Courses.Include(m => m.Images).Include(m => m.Author).Where(m => !m.SoftDeleted).Skip(skip).Take(3).ToListAsync();
            return PartialView("_CoursePartial", courses);
        }
    }
}
