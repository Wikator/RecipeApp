#nullable disable

using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
	public class Section
	{
        public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

        public List<BulletPoint> BulletPoints { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
