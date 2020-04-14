using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("tbVendas")]
    public partial class TbVendas
    {
        [Key]
        [Column("idVendas")]
        public int IdVendas { get; set; }
        [Column("idCursos")]
        public int? IdCursos { get; set; }
        [Column("idCliente")]
        public int? IdCliente { get; set; }
        [Column("Data_Compra", TypeName = "datetime")]
        public DateTime DataCompra { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbVendas))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdCursos))]
        [InverseProperty(nameof(TbCursos.TbVendas))]
        public virtual TbCursos IdCursosNavigation { get; set; }
    }
}
