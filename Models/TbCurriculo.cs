using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("tbCurriculo")]
    public partial class TbCurriculo
    {
        public TbCurriculo()
        {
            TbProfessor = new HashSet<TbProfessor>();
        }

        [Key]
        [Column("idCurriculo")]
        public int IdCurriculo { get; set; }
        [Required]
        [StringLength(150)]
        public string Graduacao { get; set; }
        [Column("Anos_Experiencia")]
        public int AnosExperiencia { get; set; }
        [Required]
        [Column("Cursos_Realizados")]
        [StringLength(300)]
        public string CursosRealizados { get; set; }

        [InverseProperty("IdCurriculoNavigation")]
        public virtual ICollection<TbProfessor> TbProfessor { get; set; }
    }
}
