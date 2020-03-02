using System;

namespace Exercicio.MinutoSeguros.Model
{
	public class FeedItem
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTimeOffset PublishDate{ get; set; }
	}
}
