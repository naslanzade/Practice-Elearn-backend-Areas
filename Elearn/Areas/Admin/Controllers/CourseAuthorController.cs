using Elearn.Areas.Admin.ViewModels.CourseAuthor;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseAuthorController : Controller
    {            

        private readonly AppDbContext _context;

        public CourseAuthorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CourseAuthorVM> list = new();
            List<Author> authors = await _context.Authors.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Author author in authors)
            {
                CourseAuthorVM model = new()
                {
                    Id = author.Id,
                    Image = author.Image,
                    FullName = author.FullName,
                    Address = author.Address,
                    CreatedDate = author.CreatedDate.ToString("MMMM dd, yyyy"),
                    Age = author.Age,
                };

                list.Add(model);
            }


            return View(list);
          
        }



        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Author dbAuthor = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (dbAuthor is null) return NotFound();

            AuthorDetailVM model = new()
            {
                Image = dbAuthor.Image,
                FullName = dbAuthor.FullName,
                CreatedDate = dbAuthor.CreatedDate.ToString("MMMM dd, yyyy"),
                Age = dbAuthor.Age,
                Address = dbAuthor.Address,
            };
            return View(model);
        }
    }
}
