using MasterChef.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Application.Validations
{
   public class CategoriaValidation :AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(a => a.Titulo).NotNull().WithMessage("poxa, coloca o {PropertyName}");
            RuleFor(a => a.Descricao).NotNull().WithMessage("poxa, coloca o {PropertyName}");
          

        }
    }
}
