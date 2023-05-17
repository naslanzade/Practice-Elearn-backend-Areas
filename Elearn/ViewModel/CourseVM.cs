using Elearn.Models;

namespace Elearn.ViewModel
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string ? Title { get; set; }
        public string ? Description { get; set; }
        public List<CourseImage> Images { get; set; }
        public decimal  Price { get; set; }
        public int SaleCount { get; set; }
        public List<Course> Courses { get; set; }
        public Course? Course { get; set; }
    }
}
