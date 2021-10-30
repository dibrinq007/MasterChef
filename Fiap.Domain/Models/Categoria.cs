using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Domain.Models
{
	public class Categoria
	{
		public string Descricao { get; set; }

		public int Id { get; set; }

		public ICollection<Receita> Receitas { get; set; }

		public string Titulo { get; set; }
	}
}
