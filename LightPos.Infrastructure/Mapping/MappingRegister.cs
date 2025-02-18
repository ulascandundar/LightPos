using LightPos.Infrastructure.Mapping.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Infrastructure.Mapping;
public static class MappingRegister
{
	public static void RegisterMapping(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(ProductCategoryProfile).Assembly);
	}
}
