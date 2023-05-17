using Elearn.Areas.Admin.ViewModels.Milestone;
using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MileStoneController : Controller
    {
        private readonly AppDbContext _context;

        public MileStoneController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {

            List<MilestoneVM> list = new();
            List<Milestone> milestones = await _context.Milestones.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Milestone milestone in milestones)
            {
                MilestoneVM model = new()
                {
                    Id = milestone.Id,
                    Logo = milestone.Logo,
                    Type = milestone.Type,
                    Counter = milestone.Counter,
                    CreatedDate = milestone.CreatedDate.ToString("MMMM dd, yyyy"),
                   
                };

                list.Add(model);
            }
            return View(list);
        }

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Milestone dbMilestone = await _context.Milestones.FirstOrDefaultAsync(m => m.Id == id);

            if (dbMilestone is null) return NotFound();

            MilestoneDetailVM model = new()
            {
                Logo = dbMilestone.Logo,
                Type = dbMilestone.Type,
                CreatedDate = dbMilestone.CreatedDate.ToString("MMMM dd, yyyy"),
                Counter = dbMilestone.Counter,
               
            };
            return View(model);
        }
    }
}
