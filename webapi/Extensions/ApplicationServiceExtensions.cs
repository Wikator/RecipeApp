using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;

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

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddScoped<IRecipeRepository, RecipeRepository>();

			return services;
		}
	}
}
