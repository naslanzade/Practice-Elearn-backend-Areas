using Elearn.Areas.Admin.ViewModels.CourseImages;
using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Elearn.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CourseImageController : Controller
    {
        private readonly AppDbContext _context;

        public CourseImageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CourseImageVM> list = new();
            List<CourseImage> courseImages = await _context.CoursesImages.Where(m => !m.SoftDeleted).Include(m=>m.Course).ToListAsync();
            foreach (CourseImage course in courseImages)
            {
                CourseImageVM model = new()
                {
                    Id = course.Id,
                   Image = course.Image,
                    IsMain = course.IsMain,
                    Course=course.Course,
                    CreatedDate = course.CreatedDate.ToString("MMMM dd, yyyy"),
                  
                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            CourseImage dbImage = await _context.CoursesImages.Include(m => m.Course).FirstOrDefaultAsync(m => m.Id == id);

            if (dbImage is null) return NotFound();

            CourseImageDetailVM model = new()
            {
                Image = dbImage.Image,
                CreatedDate = dbImage.CreatedDate.ToString("MMMM dd, yyyy"),
                IsMain=dbImage.IsMain,
                Course=dbImage.Course,
                
            };
            return View(model);
        }
    }
}
