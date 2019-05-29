using AutoMapper;
using BitCoinChallange.Application.ViewModels;
using BitCoinChallange.Domain.Queries;

namespace BitCoinChallange.Infra.CrossCutting.MapperConfigs.Profiles
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			CreateMap<SpecificationViewModel, BookSpecificationsRequest>().ConstructUsing(c =>
				new BookSpecificationsRequest(c.OriginallyPublished, c.Author, c.PageCount, c.Illustrator, c.Genres))
				.IgnoreAllPropertiesWithAnInaccessibleSetter();

			CreateMap<BookFilterViewModel, BookQueryRequest>()
				.ConstructUsing(c => new BookQueryRequest(c.Name, c.Ordering, Mapper.Map<SpecificationViewModel, BookSpecificationsRequest>(c.Specifications)));
		}
	}
}
