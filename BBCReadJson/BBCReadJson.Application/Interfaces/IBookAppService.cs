using System;
using System.Collections.Generic;
using System.Text;
using BBCReadJson.Application.ViewModels;

namespace BBCReadJson.Application.Interfaces
{
    public interface IBookAppService
    {
        IEnumerable<BookViewModel> GetBooks(string search, string order);
    }
}
