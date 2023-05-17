using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.NewAuthor
{
    public class NewsAuthorDetailVM
    {
        public string? FullName { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public ICollection<News>? News { get; set; }
        public string? CreatedDate { get; set; }
    }
}

