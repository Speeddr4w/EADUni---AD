using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("Cliente_tem_Cursos")]
    public partial class ClienteTemCursos
    {
        [Column("idCliente")]
        public int? IdCliente { get; set; }
        [Column("idPagamento")]
        public int? IdPagamento { get; set; }
        [Column("idCursos")]
        public int? IdCursos { get; set; }

        [ForeignKey(nameof(IdCliente))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdCursos))]
        public virtual TbCursos IdCursosNavigation { get; set; }
        [ForeignKey(nameof(IdPagamento))]
        public virtual TbCliente IdPagamentoNavigation { get; set; }
    }
}
