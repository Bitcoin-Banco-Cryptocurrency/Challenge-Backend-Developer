using bitcoin_project.Data;
using bitcoin_project.Model;
using System.Collections.Generic;
using System.Linq;

namespace bitcoin_project.Service
{
    public class BookService : IBookService
    {
        private readonly IBookData _bookData;
        

        public BookService(IBookData bookData)
        {
            _bookData = bookData;
        }

        public List<Book> Selecionar()
        {
            var books = _bookData.Select();
            return books;
        }

        public List<Book> SelecionarPorSpecifications(Book book)
        {
            var books = _bookData.Select(book);
            return books;
        }                

        public List<Book> SelecionarPorSpecificationOrdenarPrecoASC(Book book)
        {
            var books = SelecionarPorSpecifications(book);
            List<Book> listaOrdenada = new List<Book>();
            foreach (var b in books.OrderBy(b => b.Price))
            {
                listaOrdenada.Add(b);
            }
            return listaOrdenada;
        }

        public List<Book> SelecionarPorSpecificationOrdenarPrecoDSC(Book book)
        {
            var books = SelecionarPorSpecifications(book);
            List<Book> listaOrdenada = new List<Book>();
            foreach (var b in books.OrderByDescending(b => b.Price))
            {
                listaOrdenada.Add(b);
            }
            return listaOrdenada;
        }

        //    foreach (var prop in props.OrderByDescending(p => p.Key))
        //{
        //    jObj.Add(prop);
        //    if (prop.Value is System.Json.JsonObject)
        //        Sort2((System.Json.JsonObject) prop.Value);
        //}
    }
}
