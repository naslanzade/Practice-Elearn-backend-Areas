using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.CourseAuthor
{
    public class CourseAuthorVM
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Image { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
       public string ? CreatedDate { get; set; }
    }
}
