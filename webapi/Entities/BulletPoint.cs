#nullable disable

namespace webapi.Entities
{
	public class BulletPoint
	{
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}
