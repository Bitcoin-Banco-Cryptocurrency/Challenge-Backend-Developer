using bitcoin_project.Data;
using bitcoin_project.Model;
using bitcoin_project.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace bitcoin_project.Tests
{
    public class BookServiceTest
    {
        private readonly Mock<IBookData> _bookData;
        private readonly IBookService _service;

        public BookServiceTest()
        {
            _bookData = new Mock<IBookData>();
            _service = new BookService(_bookData.Object);
        }

        [Fact]
        public void SelecionarBookTest()
        {
            var livros = new MockDiscovery<List<Book>>(10).Obter();
            _bookData.Setup(s => s.Select()).Returns(livros);
            _service.Selecionar();
            _bookData.Verify(s => s.Select(), Times.Once);
        }

        [Fact]
        public void SelecionarPorSpecificationTest()
        {
            var book = new MockDiscovery<Book>(1).Obter();
            _service.SelecionarPorSpecifications(book);
            _bookData.Verify(s => s.Select(book), Times.Once);
        }

        [Fact]
        public void SelecionarPorSpecificationOrdenarPrecoASC()
        {
            var book = new MockDiscovery<Book>(1).Obter();
            _service.SelecionarPorSpecifications(book);
            _bookData.Verify(s => s.Select(book), Times.Once);
        }


        [Fact]
        public void SelecionarPorSpecificationOrdenarPrecoDSC()
        {
            var book = new MockDiscovery<Book>(1).Obter();
            _service.SelecionarPorSpecifications(book);
            _bookData.Verify(s => s.Select(book), Times.Once);
        }
    }

}
