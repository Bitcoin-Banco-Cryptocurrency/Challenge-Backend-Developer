using BancoBitCoin.Application.Interfaces;
using BancoBitCoin.Application.Service;
using BancoBitCoin.Domain.Application;
using BancoBitCoin.Domain.Interfaces.Application;
using BancoBitCoin.Domain.Repository;
using BancoBitCoin.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace BancoBitCoin.Test
{
    public static class UnitConfig
    {
        public static UnityContainer _container { get; set; }

        public static UnityContainer RegisterTypes()
        {
            _container = new UnityContainer();
            _container.RegisterType<IBookService, BookService>();
            _container.RegisterType<IBookRepository, BookRepository>();
            _container.RegisterType<IBookAppService, BookAppService>();

            return _container;
        }
    }
}
