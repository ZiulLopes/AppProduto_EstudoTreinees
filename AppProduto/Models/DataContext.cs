using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppProduto.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }

        public DataContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // MAPEAR TB PRODUTOS
            modelBuilder.Entity<Produto>().ToTable("TB_PRODUTOS");
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().Property(p => p.Id).HasColumnType("int").HasColumnName("IDPRODUTO").IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Name).HasColumnType("varchar").HasMaxLength(150).HasColumnName("NOMEPRODUTO").IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Description).HasColumnType("varchar").HasMaxLength(500).HasColumnName("DESCRICAOPRODUTO");
            modelBuilder.Entity<Produto>().Property(p => p.Type).HasColumnType("int").HasColumnName("IDTIPOPRODUTO").IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.DateAdd).HasColumnType("date").HasColumnName("DATACADASTRO").IsRequired();

            // MAPEAR TB TIPO PRODUTOS
            modelBuilder.Entity<TipoProduto>().ToTable("TB_TIPO_PRODUTO");
            modelBuilder.Entity<TipoProduto>().HasKey(tp => tp.IdTipoPrdto);
            modelBuilder.Entity<TipoProduto>().Property(tp => tp.IdTipoPrdto).HasColumnType("int").HasColumnName("IDTIPOPRODUTO").IsRequired();
            modelBuilder.Entity<TipoProduto>().Property(tp => tp.NomeTipoProduto).HasColumnType("varchar").HasColumnName("DESCRICAOTIPOPRODUTO").HasMaxLength(200);
        }
    }
}