namespace Elearn.Models
{
    public class Author :BaseEntity
    {
        public string ? FullName { get; set; }
        public string ? Image { get; set; }        
        public ICollection<Course> ? Courses { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }

    }
}
