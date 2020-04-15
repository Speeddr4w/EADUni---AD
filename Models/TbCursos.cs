using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("tbCursos")]
    public partial class TbCursos
    {
        public TbCursos()
        {
            TbDisciplinas = new HashSet<TbDisciplinas>();
            TbVendas = new HashSet<TbVendas>();
        }

        [Key]
        [Column("idCursos")]
        public int IdCursos { get; set; }
        [Required]
        [StringLength(150)]
        public string Ementa { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Column("Duracao_Horas")]
        public int DuracaoHoras { get; set; }
        public double Valor { get; set; }

        [InverseProperty("IdCursoNavigation")]
        public virtual ICollection<TbDisciplinas> TbDisciplinas { get; set; }
        [InverseProperty("IdCursosNavigation")]
        public virtual ICollection<TbVendas> TbVendas { get; set; }
    }
}
