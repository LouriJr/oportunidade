using Exercicio.MinutoSeguros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
			var feedResponse = _feedService.GetFeedResponse();

			return Ok();
		}

	}
}
