using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalMS.Models
{
    public class DoctorLogin
    {
        [Display(Name = "E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [DataType(DataType.EmailAddress)]
        [CustomEmailValidation(ErrorMessage = "Email must be from @lifespring.edu.tr domain.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters is required")]
        public string Password { get; set; }
    }

    public class CustomEmailValidationAttribute : ValidationAttribute
    {
        public string AllowedDomain { get; set; } = "lifespring.edu.tr";

        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return false;

            var email = value.ToString();
            var parts = email.Split('@');

            if (parts.Length == 2 && parts[1].Equals(AllowedDomain, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
    }
}