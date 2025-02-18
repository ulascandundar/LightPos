using LightPos.Core.Constants;
using LightPos.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Infrastructure.Persistence;
public static class DbRegister
{
	public static void RegisterDb(this IServiceCollection services, string connectionString)
	{
		var serviceProvider = services.BuildServiceProvider();
		var platformService = serviceProvider.GetRequiredService<IFormFactor>();
		var platform = platformService.GetFormFactor();
		platform = Platforms.Desktop;
		switch (platform)
		{
			case Platforms.Desktop:
				using (var scope = serviceProvider.CreateScope())
				{
					string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LightPos");
					Directory.CreateDirectory(appDataPath);
					string dbPath = Path.Combine(appDataPath, "LightPos2.db");
					connectionString = $"Data Source={dbPath}";
					services.AddDbContext<LightPosDbContext>(options =>
					options.UseSqlite(connectionString));
				}
				break;
			case Platforms.Web:
				services.AddDbContext<LightPosDbContext>(options =>
					options.UseSqlite(connectionString));
				break;
			default:
				throw new Exception("Platform not supported");
		}
	}
}
