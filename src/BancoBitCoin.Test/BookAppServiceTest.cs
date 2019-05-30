using BancoBitCoin.Application.Interfaces;
using BancoBitCoin.Domain.Dtos;
using BancoBitCoin.Test;
using NUnit.Framework;
using System.IO;
using System.Linq;
using Unity;

namespace Tests
{
    public class BookAppServiceTest
    {
        UnityContainer _container;
        IBookAppService _service;
        BookRequest _request;

        [SetUp]
        public void Setup()
        {
            _container = UnitConfig.RegisterTypes();
            _service = _container.Resolve<IBookAppService>();
            _request = new BookRequest();
        }

        [Test]
        public void ShouldReturnBooks()
        {
            var teste = Directory.GetCurrentDirectory();
            var books = _service.GetBooks(_request);
            Assert.IsTrue(books.Count() > 0);
        }

        [Test]
        public void ShouldReturnAbleToBooksBy_ASC_Price()
        {
            var books = _service.GetBooks(_request);
            var firstBook = books.FirstOrDefault();
            var lastBook = books.LastOrDefault();

            Assert.IsTrue(firstBook.Price < lastBook.Price);
        }

        [Test]
        public void ShouldReturnAbleToBooksBy_DESC_Price()
        {
            _request.OrderBy = BancoBitCoin.Domain.Enums.Orderby.DESC;
            var books = _service.GetBooks(_request);
            var firstBook = books.FirstOrDefault();
            var lastBook = books.LastOrDefault();

            Assert.IsTrue(firstBook.Price > lastBook.Price);
        }

        [Test]
        public void ShouldBeAbleToReturnBooks_ByName()
        {
            _request.Name = "Leagues Under";
            var books = _service.GetBooks(_request);
            Assert.IsNotNull(books);
        }
    }
}