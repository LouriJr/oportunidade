using Exercicio.MinutoSeguros.Model;
using System;
using System.Collections.Generic;

namespace Exercicio.MinutoSeguros.Tests.Unit.Mock
{
	public class RSSClientMock
	{
		public static Feed Feed()
		{
			var feedItems = new List<FeedItem>();

			for (int i = 0; i < 3; i++)
			{
				feedItems.Add(new FeedItem()
				{
					Title = $"Title {i}",
					PublishDate = DateTime.Now.Subtract(TimeSpan.FromMinutes(i)),
					Content = $"Text {i}"
				});
			}

			return new Feed() { Items = feedItems };
		}
			

		
			
	}
}
