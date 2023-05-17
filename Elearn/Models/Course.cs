namespace Elearn.Models
{

    public class Course :BaseEntity
    {
        public string ? Title { get; set; }
        public string ? Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<CourseImage> ? Images { get; set; }
        public int AuthorId { get; set; }
        public Author  ? Author { get; set; }
        public int SaleCount { get; set; }
    }
}
