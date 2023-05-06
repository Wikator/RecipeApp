using Microsoft.EntityFrameworkCore;
using webapi.Data;

namespace webapi.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services,
			IConfiguration config)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
			});

			return services;
		}
	}
}
