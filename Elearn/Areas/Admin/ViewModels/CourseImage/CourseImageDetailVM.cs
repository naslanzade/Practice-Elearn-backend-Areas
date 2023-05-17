using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.CourseImages
{
    public class CourseImageDetailVM
    {
        public string? Image { get; set; }
        public string? CreatedDate { get; set; }
        public bool IsMain { get; set; }       
        public Course ? Course { get; set; }
    }
}
