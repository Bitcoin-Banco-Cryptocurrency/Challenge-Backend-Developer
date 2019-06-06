using BooksApi.Models.Books;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Api.Models
{
    public class BookApiQuery : ObjectGraphType
    {
        public BookApiQuery(IBookRepository _bookRepository)
        {
            Field<ListGraphType<BookType>>("books",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<StringGraphType>
                    {
                        Name = "originallyPublished",
                        Description = "Book originally published date."
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "author",
                        Description = "Book author's."
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "genre",
                        Description = "Book genre."
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "illustrator",
                        Description = "Book illustrator."
                    },
                    new QueryArgument<IntGraphType>
                    {
                        Name = "pageCount",
                        Description = "Book total page count."
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "sortByPrice",
                        Description = "Sort by price Ascending or Descending."
                    }
                }),
            resolve: context =>
            {
                var books = _bookRepository.GetBooks();

                var originallyPublished = context.GetArgument<string>("originallyPublished");
                if (!string.IsNullOrEmpty(originallyPublished))
                {
                    books.RemoveAll(x => x.Specifications.OriginallyPublished != originallyPublished);
                }

                var author = context.GetArgument<string>("author");
                if (!string.IsNullOrEmpty(author))
                {
                    books.RemoveAll(x => x.Specifications.Author != author);
                }

                var pageCount = context.GetArgument<int>("pageCount");
                if (pageCount > 0)
                {
                    books.RemoveAll(x => x.Specifications.PageCount != pageCount);
                }

                var genre = context.GetArgument<string>("genre");
                if (!string.IsNullOrEmpty(genre))
                {
                    books.RemoveAll(x => x.Specifications.Genres.Contains(genre) == false);
                }

                var illustrator = context.GetArgument<string>("illustrator");
                if (!string.IsNullOrEmpty(illustrator))
                {
                    books.RemoveAll(x => x.Specifications.Illustrator.Contains(illustrator) == false);
                }

                var sortByPrice = context.GetArgument<string>("sortByPrice");
                if (!string.IsNullOrEmpty(sortByPrice))
                {
                    if (sortByPrice == "Ascending")
                        books = books.OrderBy(x => x.Price).ToList();
                    if (sortByPrice == "Descending")
                        books = books.OrderByDescending(x => x.Price).ToList();
                }

                return books.ToList();
            });
        }
    }
}