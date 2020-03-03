using System;
using System.Collections.Generic;

namespace Exercicio.MinutoSeguros.Model
{
	public class FeedItem
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTimeOffset PublishDate{ get; set; }
		public IEnumerable<Word> MostAddressedWords { get; set; }

	}
}
