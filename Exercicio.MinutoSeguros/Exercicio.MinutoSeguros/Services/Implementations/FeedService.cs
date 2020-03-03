using Exercicio.MinutoSeguros.Model;
using Exercicio.MinutoSeguros.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
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

		public Feed GetFeed()
		{
			var feed = this.GetRssFeed();

			feed.Items = feed.Items.OrderByDescending(item => item.PublishDate).Take(10);

			feed.Items.Select(item => item.MostAddressedWords = _wordService.ListWords(item.Content)).ToList();

			return feed;
		}

		private Feed GetRssFeed()
		{
			var url = _configuration["feedUrl"];

			using var reader = XmlReader.Create(url);

			return new Feed(SyndicationFeed.Load(reader));
		}
	}
}
