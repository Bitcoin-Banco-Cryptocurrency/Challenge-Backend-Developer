using BooksApi.Api.Models;
using Xunit;

namespace BooksApi.Tests.Models
{
    public class BookTypeTests
    {
        [Fact]
        public void BookType_Should_Have_Id_Price_Name_Fields()
        {
            // Act
            var bookType = new BookType();

            // Assert
            Assert.NotNull(bookType);
            Assert.True(bookType.HasField("Id"));
            Assert.True(bookType.HasField("Name"));
            Assert.True(bookType.HasField("Price"));
        }

        [Fact]
        public void BookType_Should_Have_Specifications_Field()
        {
            // Act
            var bookType = new BookType();

            // Assert
            Assert.NotNull(bookType);
            Assert.True(bookType.HasField("Specifications"));            
        }
    }
}
