using Exercicio.MinutoSeguros.Model;
using Exercicio.MinutoSeguros.Tests.Integration.Client;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Exercicio.MinutoSeguros.Tests.Integration
{
	public class FeedControllerTest
	{
		[Fact]
		public async Task Should_Validade_Number_Of_Topics_And_Number_Of_Most_Addressed_Words()
		{
			var expectedNumberOfTopics = 10;

			var expectedNumberOfMostAddressedWords = 10;

			using var client = new ApiProvider().Client;

			var apiResponse = await client.GetAsync("/feed");

			var jsonResponse = await apiResponse.Content.ReadAsStringAsync();

			var feedResponse = JsonConvert.DeserializeObject<IEnumerable<FeedResponse>>(jsonResponse);

			Assert.Equal(HttpStatusCode.OK, apiResponse.StatusCode);
			Assert.Equal(expectedNumberOfTopics, feedResponse.Count());

			foreach (var item in feedResponse)
			{
				Assert.Equal(expectedNumberOfMostAddressedWords, item.MostAddressedWords.Count());
			}
		}
	}
}
