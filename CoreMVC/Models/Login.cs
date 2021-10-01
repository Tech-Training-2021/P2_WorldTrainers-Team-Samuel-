using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class Login
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username cannot be blank")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
