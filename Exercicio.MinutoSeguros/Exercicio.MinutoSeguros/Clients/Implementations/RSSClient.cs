using Exercicio.MinutoSeguros.Clients.Interfaces.Interfaces;
using Exercicio.MinutoSeguros.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Exercicio.MinutoSeguros.Clients.Implementations
{
	public class RSSClient : IRSSClient
	{
		private readonly IConfiguration _configuration;

		public RSSClient(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public Feed GetRssFeed()
		{
			try
			{
				var url = _configuration["feedUrl"];

				using var reader = XmlReader.Create(url);

				return new Feed(SyndicationFeed.Load(reader));
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
