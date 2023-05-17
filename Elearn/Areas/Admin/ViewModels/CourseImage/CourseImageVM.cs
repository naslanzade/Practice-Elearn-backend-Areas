using Elearn.Models;


namespace Elearn.Areas.Admin.ViewModels.CourseImages
{
    public class CourseImageVM
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? CreatedDate { get; set; }
        public bool IsMain { get; set; }
        public Course ? Course { get; set; }


    }
}
