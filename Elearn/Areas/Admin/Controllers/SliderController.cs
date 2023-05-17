using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Elearn.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {

            List<SliderVM> list = new();
            List<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Slider slider in sliders)
            {
                SliderVM model = new()
                {
                    Id=slider.Id,
                    Logo=slider.Logo,
                    Title=slider.Title,
                    Description=slider.Description,
                    CreatedDate=slider.CreatedDate.ToString("MMMM dd, yyyy"),
                    Status=slider.Status,
                };

                list.Add(model);
            }
            return View(list);
        }


        [HttpGet]

        public async Task<IActionResult> Detail(int ? id)
        {

            if (id is null) return BadRequest();

            Slider dbSlider= await _context.Sliders.FirstOrDefaultAsync(m => m.Id==id);

            if (dbSlider is null) return NotFound();

            SliderDetailVM model = new()
            {
                Logo = dbSlider.Logo,
                Title = dbSlider.Title,
                CreatedDate = dbSlider.CreatedDate.ToString("MMMM dd, yyyy"),
                Status = dbSlider.Status,
                Description = dbSlider.Description,
            };
            return View(model);
        }


        
    }
}
