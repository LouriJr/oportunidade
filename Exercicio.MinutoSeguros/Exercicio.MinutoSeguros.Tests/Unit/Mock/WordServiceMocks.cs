using Exercicio.MinutoSeguros.Model;
using System.Collections.Generic;

namespace Exercicio.MinutoSeguros.Tests.Unit.Mock
{
	public class WordServiceMocks
	{
		public static string DirtyText
			=> "<p>wordOne, wordTwo</p>\n<p><b>wordOne, wordTree</b></p";

		public static IEnumerable<Word> WordsMock
			=> new List<Word>()
			{
				new Word() {Value = "wordOne", Appeared = 2},
				new Word() {Value = "wordTwo", Appeared = 1},
				new Word() {Value = "wordTree", Appeared = 1},
			};
	}
}
