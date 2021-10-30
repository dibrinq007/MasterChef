using MasterChef.Application.Interfaces;
using MasterChef.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace MasterChef.Application.Services
{
    public class ReceitaService : IReceitaService
    {
        private IMemoryCache _memoryCache;
        private IRssClient _rssClient;

        public ReceitaService(IMemoryCache memoryCache, IRssClient rssClient)
        {
            _memoryCache = memoryCache;
            _rssClient = rssClient;
        }

        public List<Receita> Load(int totalDeReceitas)
        {

            var key = $"noticias_{totalDeReceitas}";

            var Receitas = new List<Receita>();
            if (!_memoryCache.TryGetValue(key, out Receitas))
            {
                Receitas = _rssClient.Load();

                var cacheEntrieOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2));

                _memoryCache.Set(key, Receitas, cacheEntrieOptions);
            }


            return Receitas;
        }
    }
}