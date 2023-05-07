using webapi.Dtos;
using webapi.Entities;
using webapi.Helpers;

namespace webapi.Interfaces
{
	public interface IRecipeRepository
	{
		Task<PagedList<RecipeCardDto>> GetAllAsync(PaginationParams paginationParams);

		Task<RecipeDto?> GetAsync(int id);

		void Add(Recipe recipe);

		Task<bool> SaveAllAsync();
	}
}
