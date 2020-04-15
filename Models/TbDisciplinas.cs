using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("tbDisciplinas")]
    public partial class TbDisciplinas
    {
        [Key]
        [Column("idDisciplinas")]
        public int IdDisciplinas { get; set; }
        [Column("idProfessor")]
        public int? IdProfessor { get; set; }
        [Column("idCurso")]
        public int? IdCurso { get; set; }

        [ForeignKey(nameof(IdCurso))]
        [InverseProperty(nameof(TbCursos.TbDisciplinas))]
        public virtual TbCursos IdCursoNavigation { get; set; }
        [ForeignKey(nameof(IdProfessor))]
        [InverseProperty(nameof(TbProfessor.TbDisciplinas))]
        public virtual TbProfessor IdProfessorNavigation { get; set; }
    }
}
