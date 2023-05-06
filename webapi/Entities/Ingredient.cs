#nullable disable

using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
	public class Ingredient
	{
        public int Id { get; set; }

		[Required]
		public string Text { get; set; }

		public int RecipeId { get; set; }

		public Recipe Recipe { get; set; }
	}
}
