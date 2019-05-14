using System;
using System.Collections.Generic;
using System.Text;

namespace BBCReadJson.Application.ViewModels
{
    public class SpecificationsViewModel
    {
        public string OriginallyPublished { get; set; }

        public string Author { get; set; }

        public int PageCount { get; set; }

        public IEnumerable<string> Illustrator { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}
