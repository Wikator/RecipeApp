using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using webapi.Dtos;
using webapi.Entities;
using webapi.Helpers;
using webapi.Interfaces;

namespace webapi.Data
{
	public class RecipeRepository : IRecipeRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

        public RecipeRepository(ApplicationDbContext context, IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
        }

        public void Add(Recipe recipe)
		{
			_context.Recipes.Add(recipe);
		}

		public async Task<PagedList<RecipeCardDto>> GetAllAsync(PaginationParams paginationParams)
		{
			IQueryable<RecipeCardDto> recipeCardDtos = _context.Recipes.ProjectTo<RecipeCardDto>(_mapper.ConfigurationProvider).AsQueryable();

			return await PagedList<RecipeCardDto>.CreateAsync(recipeCardDtos, paginationParams.PageNumber, paginationParams.PageSize);
		}

		public async Task<RecipeDto?> GetAsync(int id)
		{
			return await _context.Recipes.Where(r => r.Id == id).ProjectTo<RecipeDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
		}

		public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
