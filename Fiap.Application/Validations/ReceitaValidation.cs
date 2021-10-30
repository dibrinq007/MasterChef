using MasterChef.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Application.Validations
{
   public class ReceitaValidation :AbstractValidator<Receita>
    {
        public ReceitaValidation()
        {
            RuleFor(a => a.Titulo).NotNull().WithMessage("poxa, coloca o {PropertyName}");
            RuleFor(a => a.Tempo).NotNull().WithMessage("poxa, coloca o {PropertyName}");
            RuleFor(a => a.Rendimento).NotNull().WithMessage("poxa, coloca o {PropertyName}");
            //RuleFor(a => a.Foto).NotEmpty().WithMessage("poxa, coloca o {PropertyName}");
            RuleFor(a => a.Preparo).NotNull().WithMessage("poxa, coloca o {PropertyName}");
            RuleFor(a => a.Ingredientes).NotNull().WithMessage("poxa, coloca o {PropertyName}");

        }
    }
}
