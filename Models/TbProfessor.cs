using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("tbProfessor")]
    public partial class TbProfessor
    {
        public TbProfessor()
        {
            TbDisciplinas = new HashSet<TbDisciplinas>();
        }

        [Key]
        [Column("idProfessor")]
        public int IdProfessor { get; set; }
        [Column("idCurriculo")]
        public int? IdCurriculo { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Column("CPF")]
        public int Cpf { get; set; }
        [Required]
        [StringLength(150)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        public int Telefone { get; set; }

        [ForeignKey(nameof(IdCurriculo))]
        [InverseProperty(nameof(TbCurriculo.TbProfessor))]
        public virtual TbCurriculo IdCurriculoNavigation { get; set; }
        [InverseProperty("IdProfessorNavigation")]
        public virtual ICollection<TbDisciplinas> TbDisciplinas { get; set; }
    }
}
