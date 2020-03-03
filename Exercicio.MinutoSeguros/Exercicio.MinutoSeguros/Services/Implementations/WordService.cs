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
			var filteredWords = Regex.Replace(string.Join(' ', text), "<.*?>", string.Empty);

			filteredWords = this.RemoveImproperWords(filteredWords);

			var wordList = filteredWords.Split(" ").Where(x => x != string.Empty);

			var MostAddressedWords = from word in wordList
									where !string.IsNullOrWhiteSpace(word) 		
                                    orderby word
                                    group word by word into wordGroup
											
                                    select new Word(){ Value = wordGroup.Key, Appeared = wordGroup.Count() };

            return MostAddressedWords.OrderByDescending(word => word.Appeared).Take(10);
		}

		private string RemoveImproperWords(string text)
		{
			//METER um to lower aqui
			return text
                .Replace("a", " ")
                .Replace("e", " ")
                .Replace("o", " ")
                .Replace("A", " ")
                .Replace("E", " ")
                .Replace("O", " ")
                .Replace("A", " ")
                .Replace("E", " ")
                .Replace("O", " ")
				.Replace("  ", " ")
                .Replace("em", " ")
                .Replace("por", " ")
                .Replace("com", " ")
                .Replace("para", " ")
                .Replace("Em", " ")
                .Replace("Por", " ")
                .Replace("Com", " ")
                .Replace("Para ", " ")
                .Replace(" as ", " ")
                .Replace(" os ", " ")
                .Replace("As ", " ")
                .Replace("Os ", " ")
                .Replace(" ao ", " ")
                .Replace(" no ", " ")
                .Replace(" na ", " ")
                .Replace(" nos ", " ")
                .Replace(" nas ", " ")
                .Replace(" um ", " ")
                .Replace(" uma ", " ")
                .Replace("Um ", " ")
                .Replace("Uma ", " ")
                .Replace(" uns ", " ")
                .Replace(" umas ", " ")
                .Replace(" á ", " ")
                .Replace(" à ", " ")
                .Replace(" é ", " ")
                .Replace(" da ", " ")
                .Replace(" do ", " ")
                .Replace(" de ", " ")
                .Replace(" das ", " ")
                .Replace(" dos ", " ")
                .Replace(" que ", " ")
                .Replace(",", " ")
                .Replace(".", " ")
                .Replace("?", " ")
                .Replace("!", " ")
				.Replace("R$", " ")
                .Replace("\n", " ");
		}
	}
}
