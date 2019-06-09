using bitcoin_project.Model;
using System.Collections.Generic;

namespace bitcoin_project.Data
{
    public interface IBookData
    {
        List<Book> Select();
        List<Book> Select(Book book);
    }
}
