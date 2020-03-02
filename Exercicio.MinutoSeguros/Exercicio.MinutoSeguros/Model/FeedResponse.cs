using System.Collections.Generic;

namespace Exercicio.MinutoSeguros.Model
{
	public class FeedResponse
	{
		public IEnumerable<string> LastTenTopics;
		public IEnumerable<Word> MostAddressedWords;
	}
}
