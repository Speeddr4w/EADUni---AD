using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD___2FA.Models
{
    [Table("tbPagamento")]
    public partial class TbPagamento
    {
        public TbPagamento()
        {
            TbCliente = new HashSet<TbCliente>();
        }

        [Key]
        [Column("idPagamento")]
        public int IdPagamento { get; set; }
        [Required]
        [Column("Forma_Pagamento")]
        [StringLength(150)]
        public string FormaPagamento { get; set; }
        [Required]
        public int Parcelas { get; set; }

        [InverseProperty("IdPagamentoNavigation")]
        public virtual ICollection<TbCliente> TbCliente { get; set; }
    }
}
