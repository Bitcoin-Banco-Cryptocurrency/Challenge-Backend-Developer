using BooksApi.Domain.Models.Books;
using GraphQL.Types;

namespace BooksApi.Api.Models
{
    public class SpecificationType : ObjectGraphType<Specification>
    {
        public SpecificationType()
        {
            Field(x => x.Author);
            Field(x => x.Genres);
            Field(x => x.OriginallyPublished);
            Field(x => x.Illustrator);
            Field(x => x.PageCount);
        }
    }
}