using Elearn.Models;

namespace Elearn.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Slider>? Sliders { get; set; }
        public IEnumerable<Course> ? Courses { get; set; }
        public Course ? Course { get; set; }
        public IEnumerable<Milestone> ? Milestones { get; set;}
        public IEnumerable<News>? News { get; set; }
        public IEnumerable<Choose>? Chooses { get; set; }
        public IEnumerable<Event> ? Event { get; set; }



    }
}
