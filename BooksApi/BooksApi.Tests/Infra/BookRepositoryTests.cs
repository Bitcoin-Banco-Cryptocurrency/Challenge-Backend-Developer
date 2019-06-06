using BooksApi.Infra.Repositories;
using Xunit;

namespace BooksApi.Tests.Infra
{
    public class BookRepositoryTests
    {
        [Fact]
        public void GetBooks_Should_Return_Five_Books()
        {
            var bookRepository = new BookRepository();

            var result = bookRepository.GetBooks();

            Assert.Equal(5, result.Count);
        }
    }
}
