using BBCReadJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBCReadJson.Application.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public SpecificationsViewModel Specifications { get; set; }
    }
}
