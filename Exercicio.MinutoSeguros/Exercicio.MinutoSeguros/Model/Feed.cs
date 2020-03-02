using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace Exercicio.MinutoSeguros.Model
{
	public class Feed
	{

		public IEnumerable<FeedItem> Items { get; set; }
		public IEnumerable<Word> MostAddressedWords { get; set; }

		public Feed(SyndicationFeed syndicationFeed)
		{
			this.Items = syndicationFeed.Items.Select(
						 item => new FeedItem() 
								 { 
									Title = item.Title.Text, 
									PublishDate = item.PublishDate,
									Content = item.ElementExtensions.ReadElementExtensions<string>("encoded", "http://purl.org/rss/1.0/modules/content/").FirstOrDefault()
								 }).ToList();

		}
	}
}
