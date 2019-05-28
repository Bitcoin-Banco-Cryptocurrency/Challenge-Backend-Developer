using BancoBitcoin.Domain.Entity;
using BancoBitcoin.Domain.Repository;
using BancoBitcoin.Repository.Util;
using System.Collections.Generic;
using System.Linq;

namespace BancoBitcoin.Repository.Entity
{
    public class BookRepository : IBookRepository
    {
        private IList<Book> Books { get; set; }

        public BookRepository()
        {
            Books = ReadJson.GetDeserializedObjectsFromJsonFile<IList<Book>>("books.json");
        }

        public IList<Book> GetBooks()
        {
            return Books.ToList();
        }

        public IList<Book> GetBooksBy(int id, string name, decimal price, bool order)
        {
            var predicate = PredicateBuilder.True<Book>();

            if (id != 0 || !string.IsNullOrEmpty(name) || price != 0)
            {
                if (id != 0)
                    predicate = predicate.And(x => x.Id == id);

                if (!string.IsNullOrEmpty(name))
                    predicate = predicate.And(x => x.Name.ToUpper().Contains(name.ToUpper()));

                if (price != 0)
                    predicate = predicate.And(x => x.Price.Equals(price));

                if (!order)
                    return Books.Where(predicate.Compile()).OrderBy(y => y.Price).ToList();
                else
                    return Books.Where(predicate.Compile()).OrderByDescending(y => y.Price).ToList();
            }
            else
                return new List<Book>();
        }

        public IList<Book> GetBooksBy(string originallyPublished, string author, int pageCount, bool order)
        {
            var predicate = PredicateBuilder.True<Book>();

            if (!string.IsNullOrEmpty(originallyPublished) || !string.IsNullOrEmpty(author) || pageCount != 0)
            {
                if (!string.IsNullOrEmpty(originallyPublished))
                    predicate = predicate.And(x => x.Specifications.OriginallyPublished.ToUpper().Contains(originallyPublished.ToUpper()));
                    
                if (!string.IsNullOrEmpty(author))
                    predicate = predicate.And(x => x.Specifications.Author.ToUpper().Contains(author.ToUpper()));
                    
                if (pageCount > 0)
                    predicate = predicate.And(x => x.Specifications.PageCount == pageCount);
                    
                if (!order)
                    return Books.Where(predicate.Compile()).OrderBy(y => y.Price).ToList();
                else
                    return Books.Where(predicate.Compile()).OrderByDescending(y => y.Price).ToList();
            }
            else
                return new List<Book>();
        }
    }
}
