using System.ComponentModel.DataAnnotations;

namespace michael_3038EFWebAPI.Models
{
    public class Course 
    {
        [Key]
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
