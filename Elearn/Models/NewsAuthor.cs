namespace Elearn.Models
{
    public class NewsAuthor :BaseEntity
    {
        public string ? FullName { get; set; }
        public int Age { get; set; }
        public string  ? Address { get; set; }
        public ICollection<News> ? News { get; set; }
    }
}
