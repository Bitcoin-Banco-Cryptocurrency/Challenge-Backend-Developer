using BTC_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTC_API.Repository
{
    public class BookRepository
    {
        /// <summary>
        /// Simulate a call to database. fill the class with books.json file information
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAll()
        {
            var list = new List<Book>();
            //===== Mock code ====
            var book = new Book();            
            var listGenre = new List<Genre>();

            book.Id = 1;
            book.Name = "Journey to the Center of the Earth";
            book.Price = 10;

            listGenre.Add(new Genre { Name = "Science Fiction" });
            listGenre.Add(new Genre { Name = "Adventure Fiction" });
                        
            book.Specification = new Specification
            {
                Published = "November 25, 1864",
                Author = "Jules Verne",
                PageCount = 183,
                Illustrator = "Édouard Riou",
                Genres = listGenre
            };
            list.Add(book);
            book = new Book();
            listGenre = new List<Genre>();
            //======================================
            book.Id = 2;
            book.Name = "20,000 Leagues Under the Sea";
            book.Price = Convert.ToDecimal(10.10);
                        
            listGenre.Add(new Genre { Name = "Adventure Fiction" });

            book.Specification = new Specification
            {
                Published = "June 20, 1870",
                Author = "Jules Verne",
                PageCount = 213,
                Illustrator = "Édouard Riou, Alphonse - Marie - Adolphe de Neuville",
                Genres = listGenre
            };
            list.Add(book);
            book = new Book();
            listGenre = new List<Genre>();
            //==================================================
            book.Id = 3;
            book.Name = "Harry Potter and the Goblet of Fire";
            book.Price = Convert.ToDecimal(7.31);

            listGenre.Add(new Genre { Name = "Fantasy  Fiction" });
            listGenre.Add(new Genre { Name = "Drama" });
            listGenre.Add(new Genre { Name = "Young adult Fiction" });
            listGenre.Add(new Genre { Name = "Mystery" });
            listGenre.Add(new Genre { Name = "Thriller" });
            listGenre.Add(new Genre { Name = "Bildungsroman" });

            book.Specification = new Specification
            {
                Published = "July 8, 2000",
                Author = "J. K. Rowling",
                PageCount = 633,
                Illustrator = "Cliff Wright, Mary GrandPré",
                Genres = listGenre
            };
            list.Add(book);
            book = new Book();
            listGenre = new List<Genre>();
            //======================================================
            book.Id = 4;
            book.Name = "Fantastic Beasts and Where to Find Them: The Original Screenplay";
            book.Price = Convert.ToDecimal(11.15);

            listGenre.Add(new Genre { Name = "Fantasy  Fiction" });
            listGenre.Add(new Genre { Name = "Contemporary fantasy" });            
            listGenre.Add(new Genre { Name = "Screenplay" });            

            book.Specification = new Specification
            {
                Published = "November 18, 2016",
                Author = "J. K. Rowling",
                PageCount = 457,
                Illustrator = "Cliff Wright",
                Genres = listGenre
            };
            list.Add(book);
            book = new Book();
            listGenre = new List<Genre>();
            //=================================================
            book.Id = 5;
            book.Name = "The Lord of the Rings";
            book.Price = Convert.ToDecimal(6.15);

            listGenre.Add(new Genre { Name = "Fantasy  Fiction" });            
            listGenre.Add(new Genre { Name = "Adventure  Fiction" });            

            book.Specification = new Specification
            {
                Published = "July 29, 1954",
                Author = "J. R. R. Tolkien",
                PageCount = 715,
                Illustrator = "Alan Lee, Ted Nashmith, J. R. R. Tolkien",
                Genres = listGenre
            };
            list.Add(book);

            return list;
        }
           
    }
}
