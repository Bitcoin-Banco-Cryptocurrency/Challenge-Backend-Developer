using GraphQL;
using GraphQL.Types;

namespace BooksApi.Api.Models
{
    public class BookApiSchema : Schema
    {
        public BookApiSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BookApiQuery>();
        }
    }
}
