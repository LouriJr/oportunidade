using Exercicio.MinutoSeguros.Model;
using Exercicio.MinutoSeguros.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace Exercicio.MinutoSeguros.Services.Implementations
{
	public class FeedService : Exercicio.MinutoSeguros.Services.Interfaces.IFeedService
	{
		private readonly IConfiguration _configuration;
		private readonly IWordService _wordService;

		public FeedService(IConfiguration configuration, IWordService wordService)
		{
			_wordService = wordService;
			_configuration = configuration;
		}

		public Feed GetFeed()
		{
			var feed = this.GetRssFeed();

			feed.Items = feed.Items.OrderByDescending(item => item.PublishDate).Take(10);

			feed.Items.Select(item => item.MostAddressedWords = _wordService.ListWords(item.Content)).ToList();

			// feed.Items.ForEach()

			// foreach (var item in feed.Items)
			// {
			// 	item.MostAddressedWords = _wordService.ListWords(item.Content);
			// }

			return feed;
		}

		private Feed GetRssFeed()
		{
			var url = "https://www.minutoseguros.com.br/blog/feed";//_configuration["feedUrl"];

			using var reader = XmlReader.Create(url);

			return new Feed(SyndicationFeed.Load(reader));
		}
	}
}
