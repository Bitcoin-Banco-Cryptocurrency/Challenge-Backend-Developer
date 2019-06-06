using BooksApi.Models.Books;
using GraphQL.Types;

namespace BooksApi.Api.Models
{
    public class BookType :ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Price);
            Field(x => x.Specifications, type: typeof(SpecificationType));
        }
    }
}
