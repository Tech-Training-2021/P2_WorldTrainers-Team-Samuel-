using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class SkillSet
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Column("Education")]
        public string Education { get; set; }

        [StringLength(50)]
        [Required]
        [Column("Experience")]
        public string Experience { get; set; }

        [StringLength(100)]
        [Required]
        [Column("Skill")]
        public string Skill { get; set; }

        [StringLength(50)]
        [Required]
        [Column("Domain")]
        public string Domain { get; set; }
        public int RegisterationId { get; set; }

        public Registeration Registeration { get; set; }
    }
}
