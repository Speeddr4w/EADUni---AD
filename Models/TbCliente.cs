using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("tbCliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbVendas = new HashSet<TbVendas>();
        }

        [Key]
        [Required]
        [Column("idCliente")]
        public int IdCliente { get; set; }
        [Column("idPagamento")]
        public int? IdPagamento { get; set; }
        [Column("Visitas_Site")]
        public int VisitasSite { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Required]
        [Column("CPF")]
        public int Cpf { get; set; }
        [Required]
        [Column("CEP")]
        public int Cep { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        public int Telefone { get; set; }

        [ForeignKey(nameof(IdPagamento))]
        [InverseProperty(nameof(TbPagamento.TbCliente))]
        public virtual TbPagamento IdPagamentoNavigation { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbVendas> TbVendas { get; set; }
    }
}
