using AutoMapper;
using webapi.Dtos;
using webapi.Entities;

namespace webapi.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Recipe, RecipeCardDto>()
				.ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => (src.Photos.FirstOrDefault(p => p.IsMain) != null) ? src.Photos.FirstOrDefault(p => p.IsMain)!.Url : null));

			CreateMap<RecipeDto, Recipe>().ReverseMap();
			CreateMap<SectionDto, Section>().ReverseMap();
			CreateMap<BulletPointDto, BulletPoint>().ReverseMap();
			CreateMap<IngredientDto, Ingredient>().ReverseMap();
			CreateMap<PhotoDto, Photo>().ReverseMap();
		}
	}
}
