using MasterChef.Domain.Models;
using MasterChef.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.ViewComponents
{
    public class ReceitasViewComponent : ViewComponent
    {
        private IReceitaService _service;

        public ReceitasViewComponent(IReceitaService service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync(int total, bool newReceitas)
        {
            var view = "Receitas";
            if (newReceitas)
            {
                view = "NewReceitas";
            }

            return View(view, _service.Load(total));
        }

        
    }
}
