using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AD___2FA.Models;

namespace AD___2FA.Data
{
    public class AD___2FAContext : DbContext
    {
        public AD___2FAContext (DbContextOptions<AD___2FAContext> options)
            : base(options)
        {
        }

        public DbSet<AD___2FA.Models.TbCliente> TbCliente { get; set; }

        public DbSet<AD___2FA.Models.TbCurriculo> TbCurriculo { get; set; }

        public DbSet<AD___2FA.Models.TbCursos> TbCursos { get; set; }

        public DbSet<AD___2FA.Models.TbDisciplinas> TbDisciplinas { get; set; }

        public DbSet<AD___2FA.Models.TbPagamento> TbPagamento { get; set; }

        public DbSet<AD___2FA.Models.TbProfessor> TbProfessor { get; set; }

        public DbSet<AD___2FA.Models.TbVendas> TbVendas { get; set; }
    }
}
