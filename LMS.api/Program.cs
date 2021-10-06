using LMS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.core.Repositories;
namespace LMS.api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

//			TestMapper.Go();


			using (var scope = host.Services.CreateScope()) { 
				App.SetUp.SeedDataAsync(scope.ServiceProvider).Wait();
			}


			//using (var scope = host.Services.CreateScope()) {
			//	var services = scope.ServiceProvider;
			//	try
			//	{
			//	scope.
			//		SeedData.InitAsync().Wait();
			//	}
			//	catch { 
			//	}
			//}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
