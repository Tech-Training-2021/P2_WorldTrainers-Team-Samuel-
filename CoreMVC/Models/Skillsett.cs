using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Models
{
    public class Skillsett
    {
        [HiddenInput]
        public int Id { get; set; }

        [StringLength(50)]
        public string Education { get; set; }

        [StringLength(50)]
        [Required]
        public string Experience { get; set; }

        [StringLength(100)]
        [Required]
        public string Skill { get; set; }

        [StringLength(50)]
        [Required]
        public string Domain { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string Email { get; set; }
    }
}
