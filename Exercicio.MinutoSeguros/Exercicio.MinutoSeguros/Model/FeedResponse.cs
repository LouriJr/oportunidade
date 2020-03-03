using System.Collections.Generic;

namespace Exercicio.MinutoSeguros.Model
{
	public class FeedResponse
	{
		public string Title { get; set; }
		public IEnumerable<Word> MostAddressedWords { get; set; }
	}
}
