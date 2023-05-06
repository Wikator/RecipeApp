#nullable disable

namespace webapi.Dtos
{
	public class RecipeDto
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Introduction { get; set; }

		public DateTime CreatedAt { get; set; }

		public List<IngredientDto> Ingredients { get; set; }

		public List<SectionDto> Sections { get; set; }

		public List<PhotoDto> Photos { get; set; }
	}
}
