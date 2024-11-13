
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace michael_3038_WebApiHomework.ViewModel
{
    public class PhoneNumberValidationAttributes : ValidationAttribute
    {
        private const string AustralianPhoneNumberPattern = @"^(\+61|61|0)?[2-478]( ?\d){8}$";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = value.ToString();
            if (Regex.IsMatch(phoneNumber, AustralianPhoneNumberPattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Not a valid Australian phone number.");
        }

    }
}
