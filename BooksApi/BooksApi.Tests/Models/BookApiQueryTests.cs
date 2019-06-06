using BooksApi.Api.Models;
using BooksApi.Models.Books;
using Moq;
using Xunit;

namespace BooksApi.Tests.Models
{
    public class BookApiQueryTests
    {
        [Fact]
        public void BookApiQuery_Should_Have_OriginallyPublished_Argument()
        {
            // Act
            var mockRepository = new Mock<IBookRepository>();
            var bookApiQuery = new BookApiQuery(mockRepository.Object);
            var booksField = bookApiQuery.GetField("books");
            var originallyPublishedArgument = booksField.Arguments.Find("originallyPublished");


            // Assert
            Assert.NotNull(bookApiQuery);
            Assert.True(bookApiQuery.HasField("books"));
            Assert.NotNull(originallyPublishedArgument);
        }

        [Fact]
        public void BookApiQuery_Should_Have_Author_Argument()
        {
            // Act
            var mockRepository = new Mock<IBookRepository>();
            var bookApiQuery = new BookApiQuery(mockRepository.Object);
            var booksField = bookApiQuery.GetField("books");
            var authorArgument = booksField.Arguments.Find("author");


            // Assert
            Assert.NotNull(bookApiQuery);
            Assert.True(bookApiQuery.HasField("books"));
            Assert.NotNull(authorArgument);
        }

        [Fact]
        public void BookApiQuery_Should_Have_Genre_Argument()
        {
            // Act
            var mockRepository = new Mock<IBookRepository>();
            var bookApiQuery = new BookApiQuery(mockRepository.Object);
            var booksField = bookApiQuery.GetField("books");
            var genreArgument = booksField.Arguments.Find("genre");


            // Assert
            Assert.NotNull(bookApiQuery);
            Assert.True(bookApiQuery.HasField("books"));
            Assert.NotNull(genreArgument);
        }

        [Fact]
        public void BookApiQuery_Should_Have_Illustrator_Argument()
        {
            // Act
            var mockRepository = new Mock<IBookRepository>();
            var bookApiQuery = new BookApiQuery(mockRepository.Object);
            var booksField = bookApiQuery.GetField("books");
            var illustratorPublishedArgument = booksField.Arguments.Find("illustrator");


            // Assert
            Assert.NotNull(bookApiQuery);
            Assert.True(bookApiQuery.HasField("books"));
            Assert.NotNull(illustratorPublishedArgument);
        }

        [Fact]
        public void BookApiQuery_Should_Have_PageCount_Argument()
        {
            // Act
            var mockRepository = new Mock<IBookRepository>();
            var bookApiQuery = new BookApiQuery(mockRepository.Object);
            var booksField = bookApiQuery.GetField("books");
            var pageCountArgument = booksField.Arguments.Find("pageCount");


            // Assert
            Assert.NotNull(bookApiQuery);
            Assert.True(bookApiQuery.HasField("books"));
            Assert.NotNull(pageCountArgument);
        }

        [Fact]
        public void BookApiQuery_Should_Have_SortByPrice_Argument()
        {
            // Act
            var mockRepository = new Mock<IBookRepository>();
            var bookApiQuery = new BookApiQuery(mockRepository.Object);
            var booksField = bookApiQuery.GetField("books");
            var sortByPriceArgument = booksField.Arguments.Find("sortByPrice");


            // Assert
            Assert.NotNull(bookApiQuery);
            Assert.True(bookApiQuery.HasField("books"));
            Assert.NotNull(sortByPriceArgument);
        }
    }
}
