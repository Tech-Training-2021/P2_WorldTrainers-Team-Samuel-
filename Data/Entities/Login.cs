using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Login")]
    public class Login
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Column("Username")]
        public string Username { get; set; }

        [StringLength(50)]
        [Required]
        [Column("Password")]
        public string Password { get; set; }

        public int RegisterationId { get; set; }

        public Registeration Registeration { get; set; }

    }
}
