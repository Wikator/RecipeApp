#nullable disable

using webapi.Entities;

namespace webapi.Dtos
{
	public class SectionDto
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public List<BulletPointDto> BulletPoints { get; set; }
	}
}
