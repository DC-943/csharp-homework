

using System.ComponentModel.DataAnnotations;

namespace michael_3038EFWebAPI.Models
{

    public class UserEF 
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "User name can't be null")]
        public virtual string? UserName { get; set; }

        public virtual string? Password { get; set; }

        [EmailAddress(ErrorMessage = "email address format it not correct")]
        public string? Email { get; set; }

        public int? age { get; set; }

        public string? Address { get; set; }

        public GenderEnum? Gender { get; set; }
        public bool? Active { get; set; }
     //   public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();

    }


}
