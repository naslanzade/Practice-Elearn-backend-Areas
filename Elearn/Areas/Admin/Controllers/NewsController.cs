using Elearn.Areas.Admin.ViewModels.New;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<NewsVM> list = new();
            List<News> news = await _context.News.Where(m => !m.SoftDeleted).Include(m=>m.Images).Include(m=>m.NewsAuthor).ToListAsync();
            foreach (News item in news)
            {
                NewsVM model = new()
                {
                    Id = item.Id,
                    Images = item.Images,
                    NewsAuthor = item.NewsAuthor,
                    Title = item.Title,
                    CreatedDate = item.CreatedDate.ToString("MMMM dd, yyyy"),
                    
                };

                list.Add(model);
            }
            return View(list);
        }



        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            News dbNews = await _context.News.Include(m => m.Images).Include(m => m.NewsAuthor).FirstOrDefaultAsync(m => m.Id == id);

            if (dbNews is null) return NotFound();

            NewsDetailVM model = new()
            {
                Images = dbNews.Images,
                Title = dbNews.Title,
                CreatedDate = dbNews.CreatedDate.ToString("MMMM dd, yyyy"),
                NewsAuthor = dbNews.NewsAuthor,
               
            };
            return View(model);
        }
    }
}
