#nullable disable

using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
	public class Photo
	{
		public int Id { get; set; }

		[Required]
		public string Url { get; set; }

		public bool IsMain { get; set; }

		[Required]
		public string PublicId { get; set; }

		public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
