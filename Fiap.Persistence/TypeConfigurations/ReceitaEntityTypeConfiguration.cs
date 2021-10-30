using MasterChef.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterChef.Core.TypeConfigurations
{
    public class ReceitaEntityTypeConfiguration : IEntityTypeConfiguration<Receita>
	{
		public void Configure(EntityTypeBuilder<Receita> builder)
		{
			builder.HasKey(r => r.Id);

			builder.HasOne(r => r.Categoria).WithMany(c => c.Receitas).HasForeignKey(fk => fk.CategoriaReceitaId);
			
			builder.Property(r => r.Titulo).IsRequired();
			builder.Property(r => r.Rendimento).IsRequired();
			builder.Property(r => r.Ingredientes).IsRequired();
			builder.Property(r => r.Foto);
			
		}
	}
}
