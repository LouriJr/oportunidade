using Exercicio.MinutoSeguros.Model;
using Exercicio.MinutoSeguros.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Exercicio.MinutoSeguros.Services.Implementations
{
	public class WordService : IWordService
	{
		public IEnumerable<Word> ListWords(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
				throw new ArgumentNullException();

			var wordList = CleanText(text);

			var mostAddressedWords = from word in wordList
									 where !string.IsNullOrWhiteSpace(word)
									 orderby word
									 group word by word into wordGroup

									 select new Word() { Value = wordGroup.Key, Appeared = wordGroup.Count() };

			return mostAddressedWords.OrderByDescending(word => word.Appeared).Take(10);
		}

		private IEnumerable<string> CleanText(string text)
		{
			var cleanedText = Regex.Replace(string.Join(' ', text), "<.*?>", string.Empty);

			var punctuation = cleanedText.Where(Char.IsPunctuation).Distinct().ToArray();

			var wordList = cleanedText.Split().Select(x => x.ToLower().Trim(punctuation));

			return RemoveImproperWords(wordList);
		}

		private IEnumerable<string> RemoveImproperWords(IEnumerable<string> wordList)
				=> (from list in wordList
					where !ImproperWords.Any(x => x == list)
					select list).ToList();

		private static IEnumerable<string> ImproperWords
				=> new List<string>()
				{
					"a","e","o","ou","em",
					"por","com","para","as",
					"os","ao","no","na","nos",
					"nas","um","uma","uns","umas",
					"á","à","é","da","do","de",
					"das","dos","que","\n","como","r$",
					"seu","esta","não", "se", "está",
					"pode", "mais", "foi", "8211",
					"este", "ser"
				};

	}
}
