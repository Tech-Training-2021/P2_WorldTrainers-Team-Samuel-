using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class RegisterationViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name cannot be blank")]
        [StringLength(maximumLength: 50, ErrorMessage = "First Name of the customer should be between 2 to 50 characters", MinimumLength = 2)]
        [DisplayName("First Name")]
        public string F_Name { get; set; }

        [Required(ErrorMessage = "Last Name cannot be blank")]
        [StringLength(maximumLength: 50, ErrorMessage = "Last Name of the customer should be between 2 to 50 characters", MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string L_Name { get; set; }

        [Required(ErrorMessage = "Contact cannot be blank")]
        [DisplayName("Contact")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Should contain 10digits")]
        public int Mobile { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Should be in the format of abc@gmail.com")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Location cannot be blank")]
        [DisplayName("Location")]
        public string Locations { get; set; }


        [Required(ErrorMessage = "Username cannot be blank")]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be blank")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Role")]
        public int Role_id { get; set; }
    }
}
