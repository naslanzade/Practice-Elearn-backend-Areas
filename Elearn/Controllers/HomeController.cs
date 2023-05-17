
using Elearn.Data;
using Elearn.Models;
using Elearn.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Elearn.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDeleted).ToListAsync();
            Course course = await _context.Courses.Where(m=>!m.SoftDeleted).Include(m => m.Images).Include(m => m.Author).Take(1).OrderByDescending(m=>m.CreatedDate).FirstOrDefaultAsync();
            IEnumerable<Course> courses = await _context.Courses.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m=>m.Author).ToListAsync();
            IEnumerable<Milestone> milestones = await _context.Milestones.Where(m => !m.SoftDeleted).ToListAsync();
            IEnumerable<News> news=await _context.News.Where(m => !m.SoftDeleted).Include(m=>m.Images).Include(m=>m.NewsAuthor).OrderByDescending(m => m.CreatedDate).ToListAsync();
            IEnumerable<Choose> chooses=await _context.Chooses.Where(m=>!m.SoftDeleted).ToListAsync();
            IEnumerable<Event> events = await _context.Events.Where(m => !m.SoftDeleted).OrderByDescending(m => m.CreatedDate).ToListAsync();

            HomeVM homeVM = new() { 
            
                Sliders = sliders,
                Course = course,
                Milestones= milestones,
                News= news,
                Chooses= chooses,
                Event= events,
                Courses= courses,
            };


            return View(homeVM);
        }

      
    }
}