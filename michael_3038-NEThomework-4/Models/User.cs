using System.ComponentModel.DataAnnotations;
using michael_3038_WebApiHomework.ViewModel;
namespace michael_3038_WebApiHomework.Models
{
    public enum GenderEnum
    {
        Male = 0,
        Female = 1,
        Other = 2,
    }

    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="username cannot be null")]
        public string? UserName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }

        [EnumDataType(typeof(GenderEnum),ErrorMessage ="Invalid enum ")]
        public GenderEnum Gender { get; set; }
        public string? Password { get; set; }

        [Required(ErrorMessage ="Phone cannot be null")]
        [PhoneNumberValidationAttributes(ErrorMessage = "Please provide a valid phone number")]
        public string? Phone { get; set; }
    }

}
