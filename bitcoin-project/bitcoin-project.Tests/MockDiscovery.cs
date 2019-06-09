using bitcoin_project.Model;
using System;
using System.Collections.Generic;
using Xunit;
using FizzWare.NBuilder;


namespace bitcoin_project.Tests
{
    public class MockDiscovery<T>
    {
        public int Count { get; set; }

        public MockDiscovery()
        {
            Count = 1;
        }

        public MockDiscovery(int count)
        {
            Count = count;
        }

        public T Obter()
        {
            Type tipo = typeof(T);
            if (tipo == typeof(Book))
                return (T)Convert.ChangeType(GetBookMock(), tipo);
            if (tipo == typeof(List<Book>))
                return (T)Convert.ChangeType(GetManyBookMock(), tipo);
            return default(T);
        }

        private IList<Book> GetManyBookMock()
        {
            var obj = Builder<Book>.CreateListOfSize(Count).Build();
            for (int i = 0; i < obj.Count; i++)
            {
                obj[i] = GetBookMock();
            }
            return obj;
        }

        private Book GetBookMock()
        {
            Book obj = Builder<Book>.CreateNew().Build();
            obj.Specifications = Builder<Specifications>.CreateNew().Build();
            return obj;
        }
    }
}