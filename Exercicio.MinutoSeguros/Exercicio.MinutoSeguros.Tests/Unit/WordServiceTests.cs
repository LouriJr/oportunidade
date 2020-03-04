using Exercicio.MinutoSeguros.Services.Implementations;
using Exercicio.MinutoSeguros.Tests.Unit.Mock;
using System;
using System.Linq;
using Xunit;

namespace Exercicio.MinutoSeguros.Tests.Unit
{
	public class WordServiceTests
	{
		private readonly WordService _wordService;

		public WordServiceTests()
		{
			_wordService = new WordService();
		}

		[Fact]
		public void Should_Return_List_Of_Words()
		{
			var expectedNumberOfWords = 3;

			var listOfWords = _wordService.ListWords(WordServiceMocks.DirtyText);

			Assert.Equal(expectedNumberOfWords, listOfWords.Count());
		}

		[Fact]
		public void Should_Throw_Argument_Null_Exception_When_Text_Is_Null()
		{
			Assert.Throws<ArgumentNullException>(() => _wordService.ListWords(""));
		}
	}
}
