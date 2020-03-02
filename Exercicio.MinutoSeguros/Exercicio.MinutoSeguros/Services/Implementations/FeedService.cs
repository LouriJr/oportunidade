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
	public class FeedService : IFeedService
	{
		private readonly IConfiguration _configuration;
		private readonly IWordService _wordService;

		public FeedService(IConfiguration configuration, IWordService wordService)
		{
			_wordService = wordService;
			_configuration = configuration;
		}

		public FeedResponse GetFeedResponse()
		{
			var feed = this.GetFeed();

			var lastTenTopics = feed.Items.OrderByDescending(item => item.PublishDate).Take(10);

			var filteredWords = feed.Items.Select(item => _wordService.ListWords(item.Content));

			return new FeedResponse()
			{
				LastTenTopics = lastTenTopics.Select(x => x.Title),
				MostAddressedWords = feed.MostAddressedWords
			};

		}

		private Feed GetFeed()
		{
			var url = _configuration["feedUrl"];

			using var reader = XmlReader.Create(url);

			return new Feed(SyndicationFeed.Load(reader));
		}
	}
}
