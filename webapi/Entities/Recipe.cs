#nullable disable

using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
	public class Recipe
	{
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Introduction { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Section> Sections { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
