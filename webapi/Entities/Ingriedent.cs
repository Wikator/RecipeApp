#nullable disable

using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
	public class Ingriedent
	{
        public int Id { get; set; }

		[Required]
		public string Ingredient { get; set; }

		public int RecipeId { get; set; }

		public Recipe Recipe { get; set; }
	}
}
