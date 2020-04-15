using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AD___2FA.Models
{
    public partial class AdventureContext : DbContext
    {
        public AdventureContext()
        {
        }

        public AdventureContext(DbContextOptions<AdventureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteTemCursos> ClienteTemCursos { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbCurriculo> TbCurriculo { get; set; }
        public virtual DbSet<TbCursos> TbCursos { get; set; }
        public virtual DbSet<TbDisciplinas> TbDisciplinas { get; set; }
        public virtual DbSet<TbPagamento> TbPagamento { get; set; }
        public virtual DbSet<TbProfessor> TbProfessor { get; set; }
        public virtual DbSet<TbVendas> TbVendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-M3LNJ78\\SQLEXPRESS;Database=TrabalhoSupremo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteTemCursos>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Cliente_t__idCli__4CA06362");

                entity.HasOne(d => d.IdCursosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCursos)
                    .HasConstraintName("FK__Cliente_t__idCur__4E88ABD4");

                entity.HasOne(d => d.IdPagamentoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPagamento)
                    .HasConstraintName("FK__Cliente_t__idPag__4D94879B");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__tbClient__885457EE108E9F59");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdPagamentoNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.IdPagamento)
                    .HasConstraintName("FK__tbCliente__idPag__46E78A0C");
            });

            modelBuilder.Entity<TbCurriculo>(entity =>
            {
                entity.HasKey(e => e.IdCurriculo)
                    .HasName("PK__tbCurric__B63B1EA13B033B9C");

                entity.Property(e => e.CursosRealizados).IsUnicode(false);

                entity.Property(e => e.Graduacao).IsUnicode(false);
            });

            modelBuilder.Entity<TbCursos>(entity =>
            {
                entity.HasKey(e => e.IdCursos)
                    .HasName("PK__tbCursos__DFABD131A2E8A2AE");

                entity.Property(e => e.Ementa).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<TbDisciplinas>(entity =>
            {
                entity.HasKey(e => e.IdDisciplinas)
                    .HasName("PK__tbDiscip__639A32814E90AE6F");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.TbDisciplinas)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__tbDiscipl__idCur__3E52440B");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.TbDisciplinas)
                    .HasForeignKey(d => d.IdProfessor)
                    .HasConstraintName("FK__tbDiscipl__idPro__3D5E1FD2");
            });

            modelBuilder.Entity<TbPagamento>(entity =>
            {
                entity.HasKey(e => e.IdPagamento)
                    .HasName("PK__tbPagame__866960F699D2D64E");

                entity.Property(e => e.FormaPagamento).IsUnicode(false);
            });

            modelBuilder.Entity<TbProfessor>(entity =>
            {
                entity.HasKey(e => e.IdProfessor)
                    .HasName("PK__tbProfes__4E7C3C6D97B094C4");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdCurriculoNavigation)
                    .WithMany(p => p.TbProfessor)
                    .HasForeignKey(d => d.IdCurriculo)
                    .HasConstraintName("FK__tbProfess__idCur__3A81B327");
            });

            modelBuilder.Entity<TbVendas>(entity =>
            {
                entity.HasKey(e => e.IdVendas)
                    .HasName("PK__tbVendas__D7C624B5161A4FC5");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbVendas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__tbVendas__idClie__4AB81AF0");

                entity.HasOne(d => d.IdCursosNavigation)
                    .WithMany(p => p.TbVendas)
                    .HasForeignKey(d => d.IdCursos)
                    .HasConstraintName("FK__tbVendas__idCurs__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
