using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.Courses
{
    public class CourseDetailVM
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<CourseImage>? Images { get; set; }       
        public Author? Author { get; set; }
        public int SaleCount { get; set; }
        public string? CreatedDate { get; set; }
    }
}
