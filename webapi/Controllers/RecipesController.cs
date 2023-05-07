using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Entities;
using webapi.Extensions;
using webapi.Helpers;
using webapi.Interfaces;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController : ControllerBase
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IMapper _mapper;

        public RecipesController(IRecipeRepository recipeRepository, IMapper mapper)
        {
			_recipeRepository = recipeRepository;
			_mapper = mapper;
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<RecipeCardDto>>> GetRecipes([FromQuery]PaginationParams paginationParams)
		{
			PagedList<RecipeCardDto> recipes = await _recipeRepository.GetAllAsync(paginationParams);

			Response.AddPaginationHeader(recipes.GetPaginationHeader());

			return Ok(recipes);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
		{
			RecipeDto? recipeDto = await _recipeRepository.GetAsync(id);

			if (recipeDto is null)
			{
				return NotFound("Recipe not found");
			}

			return Ok(recipeDto);
		}

		[HttpPost]
		public async Task<ActionResult<Recipe>> CreateRecipe(RecipeDto recipeDto)
		{
			Recipe recipe = _mapper.Map<Recipe>(recipeDto);
			_recipeRepository.Add(recipe);

			if (await _recipeRepository.SaveAllAsync())
			{
				return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipeDto);
			}

			return BadRequest("Failed to create recipe");
		}

		[HttpPost("seed")]
		public async Task<ActionResult> SeedRecipes()
		{
			for (int i = 0; i < 100; i++)
			{
				Recipe recipe = new()
				{
					Title = $"Recipe {i}",
					Introduction = $"Description {i}",
					Ingredients = new List<Ingredient>() { new Ingredient() { Text= $"Milk: {i} glasses" }, new Ingredient() { Text = $"Butter: {i} spoons" } },
					Sections = new List<Section>() { new Section() { Title = "Section 1", Description= (i % 2 ==0) ? null : "Lorem ipsum, dolor sit amet", BulletPoints= new List<BulletPoint>() } },
					Photos = new List<Photo>(),
				};
				_recipeRepository.Add(recipe);
			}

			if (await _recipeRepository.SaveAllAsync())
			{
				return Ok();
			}

			return BadRequest("Something went wrong when seeding recipes");
		}
    }
}
