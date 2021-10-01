using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class Registeration
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
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public int Mobile { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Location cannot be blank")]
        [DisplayName("Location")]
        public string Locations { get; set; }
        [DisplayName("Role")]
        public int Role_id { get; set; }
    }
}
