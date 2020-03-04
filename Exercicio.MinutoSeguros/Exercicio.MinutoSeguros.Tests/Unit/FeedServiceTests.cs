using Exercicio.MinutoSeguros.Clients;
using Exercicio.MinutoSeguros.Services.Implementations;
using Exercicio.MinutoSeguros.Services.Interfaces;
using Exercicio.MinutoSeguros.Tests.Unit.Mock;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace Exercicio.MinutoSeguros.Tests.Unit
{
	public class FeedServiceTests
	{
		[Fact]
		public void Should_Get_Feed_With_Tree_Topics()
		{
			var expectedNumberOfTopics = 3;

			var rssClient = Substitute.For<IRSSClient>();
			rssClient.GetRssFeed().Returns(RSSClientMock.Feed());

			var wordService = Substitute.For<IWordService>();
			wordService.ListWords(Arg.Any<string>()).Returns(WordServiceMocks.WordsMock);

			var feedService = new FeedService(rssClient, wordService);

			var feed = feedService.GetFeed();

			Assert.Equal(expectedNumberOfTopics, feed.Items.Count());

		}

		[Fact]
		public void Should_Throw_Argument_Null_Exception_When_Text_Is_Null()
		{
			var expectedExceptionMessage = "Could not load RSS feed";

			var rssClient = Substitute.For<IRSSClient>();
			rssClient.GetRssFeed().ReturnsForAnyArgs(r => null);

			var wordService = Substitute.For<IWordService>();
			wordService.ListWords(Arg.Any<string>()).ReturnsForAnyArgs(r => null);

			var feedService = new FeedService(rssClient, wordService);

			var exception = Assert.Throws<Exception>(() => feedService.GetFeed());

			Assert.Equal(expectedExceptionMessage, exception.Message);
		}
	}
}
