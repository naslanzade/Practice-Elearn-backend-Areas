using Elearn.Areas.Admin.ViewModels.Choose;
using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChooseController : Controller
    {
        private readonly AppDbContext _context;

        public ChooseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ChooseVM> list = new();
            List<Choose> chooses = await _context.Chooses.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Choose choose in chooses)
            {
                ChooseVM model = new()
                {
                    Id = choose.Id,
                    Question = choose.Question,
                    Answer = choose.Answer,                    
                    CreatedDate = choose.CreatedDate.ToString("MMMM dd, yyyy"),
                    
                };

                list.Add(model);
            }
            return View(list);
        }


        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Choose dbChoose = await _context.Chooses.FirstOrDefaultAsync(m => m.Id == id);

            if (dbChoose is null) return NotFound();

            ChooseDetailVM model = new()
            {
               
                Question = dbChoose.Question,
                Answer = dbChoose.Answer,
                CreatedDate = dbChoose.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
