using Exercicio.MinutoSeguros.Model;
using System.Collections.Generic;

namespace Exercicio.MinutoSeguros.Services.Interfaces
{
	public interface IWordService
	{
		IEnumerable<Word> ListWords(string text);
	}
}
