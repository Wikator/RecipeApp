using webapi.Dtos;
using webapi.Entities;

namespace webapi.Interfaces
{
	public interface IRecipeRepository
	{
		Task<IEnumerable<RecipeCardDto>> GetAllAsync();

		Task<RecipeDto?> GetAsync(int id);

		void Add(Recipe recipe);

		Task<bool> SaveAllAsync();
	}
}
