using Elearn.Areas.Admin.ViewModels.Courses;
using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class CourseController : Controller
    {

        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CourseVM> list = new();
            List<Course> courses= await _context.Courses.Include(m => m.Author).Include(m=>m.Images).Where(m => !m.SoftDeleted).ToListAsync();
            foreach (var course in courses) {

                CourseVM model = new()
                {

                    Id = course.Id,  
                    Images= course.Images,
                    Title = course.Title,
                    Description = course.Description,
                    CreatedDate = course.CreatedDate.ToString("MMMM dd, yyyy"),
                    Author = course.Author,
                    SaleCount= course.SaleCount,
                    Price = course.Price,
                };

                list.Add(model);
            
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Course dbCourse = await _context.Courses.Include(m => m.Author).Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);

            if (dbCourse is null) return NotFound();

            CourseDetailVM model = new()
            {
                Images = dbCourse.Images,
                Title = dbCourse.Title,
                CreatedDate = dbCourse.CreatedDate.ToString("MMMM dd, yyyy"),
                Price = dbCourse.Price,
                Description = dbCourse.Description,
                Author = dbCourse.Author,
                SaleCount= dbCourse.SaleCount,
            };
            return View(model);
        }
    }
}
