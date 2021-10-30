using CodeHollow.FeedReader;
using MasterChef.Application.Interfaces;
using MasterChef.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Infrastructer.Clients
{
    public class RssGloboClient : IRssClient
    {
        private string _feedUrl;

        public RssGloboClient(string feedUrl)
        {
            _feedUrl = feedUrl;
        }
        public List<Receita> Load()
        {
            var receitas = new List<Receita>();
            var feed = FeedReader.ReadAsync(_feedUrl).Result;

            foreach (var item in feed.Items)
            {
                var feedItem = item.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;
                var media = feedItem.Media;
                var url = "";
                if (media.Any())
                    url = media.FirstOrDefault().Url;
                receitas.Add(new Receita() { Id = 1, Titulo = item.Title });
            }
            return receitas;
        }
    }
}
