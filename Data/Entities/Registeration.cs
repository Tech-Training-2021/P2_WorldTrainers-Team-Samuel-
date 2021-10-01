using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Registeration")]
    public class Registeration
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Column("F_Name")]
        public string F_Name { get; set; }

        [StringLength(50)]
        [Required]
        [Column("L_Name")]
        public string L_Name { get; set; }

        [StringLength(50)]
        [Required]
        [Column("Contact")]
        public int Contact { get; set; }

        [StringLength(50)]
        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [StringLength(150)]
        [Column("Locations")]
        public string Locations { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
