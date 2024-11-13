using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace michael_3038EFWebAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// this is a test1
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// this is a test2
        /// </summary>
        public int CategoryLevel { get; set; } 

        public int? ParentId { get; set; } 

        public Category? Parent { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 
    }
}
