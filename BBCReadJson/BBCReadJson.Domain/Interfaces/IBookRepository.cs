using System;
using System.Collections.Generic;
using System.Text;
using BBCReadJson.Domain.Models;

namespace BBCReadJson.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
    }
}
