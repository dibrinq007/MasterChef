using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Domain.Models
{
	public class Receita
	{
		
		public int CategoriaReceitaId { get; set; }
		public int Id { get; set; }
		public string Titulo { get; set; }
		public byte[] Foto { get; set; }
        public int Tempo { get; set; }
        public int Rendimento { get; set; }
		public string Ingredientes { get; set; }
		public string Preparo { get; set; }

		public Categoria Categoria { get; set; }

	}
}
