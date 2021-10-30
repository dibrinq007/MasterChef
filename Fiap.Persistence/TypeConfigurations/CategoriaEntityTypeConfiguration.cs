using MasterChef.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterChef.Core.TypeConfigurations
{
	public class CategoriaEntityTypeConfiguration : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder.HasKey(c => c.Id);

			builder.HasMany(c => c.Receitas).WithOne(r => r.Categoria).HasForeignKey(fk => fk.CategoriaReceitaId);

			builder.Property(c => c.Descricao).IsRequired();
			builder.Property(c => c.Titulo).IsRequired();
		}
	}
}
