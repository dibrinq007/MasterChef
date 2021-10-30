using System.Collections.Generic;
using MasterChef.Domain.Models;

namespace MasterChef.Application.Services
{
    public interface IReceitaService
    {
        List<Receita> Load(int totalDeNoticias);
    }
}