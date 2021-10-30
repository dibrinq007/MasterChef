using MasterChef.Domain.Models;
using System.Collections.Generic;

namespace MasterChef.Application.Interfaces
{
    public interface IRssClient
    {
        public List<Receita> Load();
    }
}
