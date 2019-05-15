using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BBCReadJson.Application.AutoMapper;
using BBCReadJson.Application.Interfaces;
using BBCReadJson.Application.Services;
using BBCReadJson.Application.ViewModels;
using BBCReadJson.Domain.Interfaces;
using BBCReadJson.Infra.Data.Repositories;
using BBCReadJson.Services.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BBCReadJson.Test
{
    public class UnitTest
    {
        public UnitTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new DomainToViewModelMappingProfile()));
            var _mapper = new Mapper(configuration);

            _bookRepository = new BookRepository();
            _service = new BookAppService(_mapper, _bookRepository);
            _controller = new BooksController(_service);
        }

        private readonly BooksController _controller;
        private readonly IBookAppService _service;
        private IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        [Fact]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Act
            var result = _controller.GetBooks("", "");

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(
                viewResult.Value);
            Assert.Equal(5, model.Count());
        }

        [Fact]
        public void GetAllBooks_ShouldNotFindBook()
        {
            // Act
            var result = _controller.GetBooks("dfadfadfljkhlkjh", "");

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(
                viewResult.Value);
            Assert.Equal(0, model.Count());
        }

        [Fact]
        public void GetAllBooks_ShouldReturnCorrectProductByName()
        {
            // Act
            var result = _controller.GetBooks("Journey to the Center of the Earth", "");

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(
                viewResult.Value);
            Assert.Equal("Journey to the Center of the Earth", model.FirstOrDefault().Name);
        }
    }
}