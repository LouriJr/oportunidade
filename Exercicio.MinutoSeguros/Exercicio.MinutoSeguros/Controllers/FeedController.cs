using Exercicio.MinutoSeguros.Model;
using Exercicio.MinutoSeguros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Exercicio.MinutoSeguros.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FeedController : ControllerBase
	{
		private readonly IFeedService _feedService;

		public FeedController(IFeedService feedService)
		{
			_feedService = feedService;
		}

		[HttpGet]
		public IActionResult Get()	
		{
			var feed = _feedService.GetFeed();

			var feedResponses = feed.Items
			.Select(item => new FeedResponse() 
			{
				Title = item.Title,
				MostAddressedWords = item.MostAddressedWords
			});

			return Ok(feedResponses);
		}

	}
}
