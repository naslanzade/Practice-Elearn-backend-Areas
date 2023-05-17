using Elearn.Models;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opttion) : base(opttion)
        {

        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CoursesImages { get; set;}
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Choose> Chooses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<NewsAuthor> NewsAuthors { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsImage> NewsImages { get; set; }


    }
}
