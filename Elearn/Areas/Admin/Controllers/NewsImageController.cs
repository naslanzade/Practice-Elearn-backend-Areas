
using Elearn.Areas.Admin.ViewModels.NewImage;
using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsImageController : Controller
    {
        private readonly AppDbContext _context;

        public NewsImageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            List<NewImageVM> list = new();
            List<NewsImage> newsImages = await _context.NewsImages.Where(m => !m.SoftDeleted).Include(m=>m.News).ToListAsync();
            foreach (NewsImage item in newsImages)
            {
                NewImageVM model = new()
                {
                    Id = item.Id,
                    Image = item.Image,
                    IsMain = item.IsMain,                    
                    CreatedDate = item.CreatedDate.ToString("MMMM dd, yyyy"),
                    News = item.News,
                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            NewsImage dbImage = await _context.NewsImages.Include(m=>m.News).FirstOrDefaultAsync(m => m.Id == id);

            if (dbImage is null) return NotFound();

            NewImageDetailVM model = new()
            {
                Image = dbImage.Image,
                IsMain = dbImage.IsMain,
                CreatedDate = dbImage.CreatedDate.ToString("MMMM dd, yyyy"),
                News = dbImage.News,
                
            };
            return View(model);
        }
    }
}
