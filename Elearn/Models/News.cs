namespace Elearn.Models
{
    public class News :BaseEntity
    {
        public string ? Title { get; set; }
        public int NewsAuthorId { get; set; }
        public NewsAuthor ? NewsAuthor { get; set; }
        public ICollection<NewsImage> ? Images { get; set; }
    }
}
