using bitcoin_project.Model;
using System;
using System.Collections.Generic;

namespace bitcoin_project.Service
{
    public interface IBookService
    {
        List<Book> Selecionar();
        List<Book> SelecionarPorSpecifications(Book book);
        List<Book> SelecionarPorSpecificationOrdenarPrecoASC(Book book);
        List<Book> SelecionarPorSpecificationOrdenarPrecoDSC(Book book);
    }
}
