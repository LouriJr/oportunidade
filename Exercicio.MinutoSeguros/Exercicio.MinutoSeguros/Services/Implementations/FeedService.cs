using Exercicio.MinutoSeguros.Clients.Interfaces.Interfaces;
using Exercicio.MinutoSeguros.Model;
using Exercicio.MinutoSeguros.Services.Interfaces;
using System;
using System.Linq;

namespace Exercicio.MinutoSeguros.Services.Implementations
{
	public class FeedService : IFeedService
	{
		private readonly IRSSClient _rssClient;
		private readonly IWordService _wordService;

		public FeedService(IRSSClient rssClient, IWordService wordService)
		{
			_rssClient = rssClient;
			_wordService = wordService;
		}

		public Feed GetFeed()
		{
			var feed = _rssClient.GetRssFeed();

			if (feed == null)
				throw new Exception("Could not load RSS feed");

			feed.Items = feed.Items.OrderByDescending(item => item.PublishDate).Take(10);

			feed.Items.Select(item => item.MostAddressedWords = _wordService.ListWords(item.Content)).ToList();

			return feed;
		}
	}
}
