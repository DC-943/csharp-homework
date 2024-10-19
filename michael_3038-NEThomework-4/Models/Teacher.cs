using System.ComponentModel.DataAnnotations;

namespace michael_3038_WebApiHomework.Models
{
    public class Teacher
    {
       [Required(ErrorMessage ="id cannot be null")]
       public int TeacherId { get; set; }
       public int UserId { get; set; }
       public User user { get; set; }

       [Required(ErrorMessage = "Department cannot be null")]
       public string Department { get; set;}

       [MaxLength(500, ErrorMessage ="max length is 500")]
       public string Description { get; set; }
       public string Specialty { get; set; }

    }
}
