using LightPos.Core.Application.IServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Application.Services;
public static class ServiceRegister
{
	public static void RegisterService(this IServiceCollection services)
	{
		services.AddScoped<ISelfService, SelfService>();
	}
}
