using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.New
{
    public class NewsDetailVM
    {
        public string? Title { get; set; }
        public int NewsAuthorId { get; set; }
        public NewsAuthor? NewsAuthor { get; set; }
        public ICollection<NewsImage>? Images { get; set; }
        public string? CreatedDate { get; set; }
    }
}
