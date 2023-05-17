using Elearn.Areas.Admin.ViewModels.NewAuthor;
using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsAuthorController : Controller
    {
        private readonly AppDbContext _context;

        public NewsAuthorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<NewsAuthorVM> list = new();
            List<NewsAuthor> newsAuthors = await _context.NewsAuthors.Where(m => !m.SoftDeleted).Include(m=>m.News).ToListAsync();
            foreach (NewsAuthor item in newsAuthors)
            {
                NewsAuthorVM model = new()
                {
                    Id = item.Id,
                    FullName=item.FullName,
                    Age = item.Age,
                    Address = item.Address,
                    CreatedDate = item.CreatedDate.ToString("MMMM dd, yyyy"),
                    News=item.News
                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            NewsAuthor dbAuthor = await _context.NewsAuthors.Include(m => m.News).FirstOrDefaultAsync(m => m.Id == id);

            if (dbAuthor is null) return NotFound();

            NewsAuthorDetailVM model = new()
            {
                FullName = dbAuthor.FullName,
                Age = dbAuthor.Age,
                CreatedDate = dbAuthor.CreatedDate.ToString("MMMM dd, yyyy"),
                Address = dbAuthor.Address,
                News = dbAuthor.News,
            };
            return View(model);
        }
    }
}
