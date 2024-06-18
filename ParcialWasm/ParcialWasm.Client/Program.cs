using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ParcialWasm.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			// Inject HttpClient with base URL
			builder.Services.AddScoped(sp =>
			new HttpClient
			{
				BaseAddress = new Uri("https://localhost:7148/")
			});

			await builder.Build().RunAsync();
		}
	}
}
