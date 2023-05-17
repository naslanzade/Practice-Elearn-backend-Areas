using Elearn.Areas.Admin.ViewModels.Event;
using Elearn.Areas.Admin.ViewModels.Slider;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {

        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            List<EventVM> list = new();
            List<Event> events = await _context.Events.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Event item in events)
            {
                EventVM model = new()
                {
                    Id = item.Id,
                    Heading = item.Heading,
                    Day = item.Day,
                    Description = item.Description,
                    CreatedDate = item.CreatedDate.ToString("MMMM dd, yyyy"),
                    Month = item.Month,
                };

                list.Add(model);
            }
            return View(list);
        }



        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Event dbEvent = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (dbEvent is null) return NotFound();

            EventDetailVM model = new()
            {
                Heading = dbEvent.Heading,
                Description = dbEvent.Description,
                CreatedDate = dbEvent.CreatedDate.ToString("MMMM dd, yyyy"),
                Day = dbEvent.Day,
                Month = dbEvent.Month,

                
            };
            return View(model);
        }
    }
}
