using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace Exercicio.MinutoSeguros.Tests.Integration.Client
{
	public class ApiProvider : IDisposable
	{
		private TestServer server;
		public HttpClient Client { get; private set; }

		public ApiProvider()
		{
			server = new TestServer(new WebHostBuilder()
				 .ConfigureAppConfiguration((builderContext, config) =>
				 {
					 var env = builderContext.HostingEnvironment;
					 config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
				 })
				.UseStartup<Startup>());
			Client = server.CreateClient();
		}

		public void Dispose()
		{
			server?.Dispose();
			Client?.Dispose();
		}
	}
}
