using MasterChef.Core.TypeConfigurations;
using MasterChef.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterChef.Persistence.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public  virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Receita> Receitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReceitaEntityTypeConfiguration());
        }
    }
}
