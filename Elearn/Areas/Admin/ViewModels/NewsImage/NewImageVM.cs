using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.NewImage
{
    public class NewImageVM
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public bool IsMain { get; set; }
        public int NewsId { get; set; }
        public News? News { get; set; }
        public string ? CreatedDate { get; set; }
    }
}
