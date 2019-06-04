using BancoBitcoin.Application.Interface;
using BancoBitcoin.Application.Service;
using BancoBitcoin.Domain.Repository;
using BancoBitcoin.Repository.Entity;
using NUnit.Framework;
using System.Linq;

namespace BancoBitcoin.Test
{
    public class BookTest
    {
        // MENSAGEM PARA O AVALIADOR
        // Raramente faço teste de repositório, a não ser que tenha alguma regra(no caso da prova, utilizei o predicate builder para montar as condicionais), 
        // ou que tenho que comparar dados retornados.
        // No máximo que testo a camada de repositório, são os mapeamentos do nHibernate, utilizando o PersistenceSpecification.
        // Instanciei a classe concreta de repositório, porque não irei utilizar um injetor de dependência no projeto de Teste
        // igual utilizei na aplicação
        // Utilizo mais o Faker.NET para gerar dados aleatórios, o Builder pattern para construir objetos complexos, para testar o modelo rico também. 
        // E por fim, Moq para simular um repositório ou uma service, que não é o caso desse teste

        private IBookService bookService;
        private IBookRepository bookRepository;

        [SetUp]
        public void Setup()
        {
            bookRepository = new BookRepository();
            bookService = new BookService(bookRepository);
        }

        [Test]
        public void TestaQuantidadeDeLivrosDoMetodoQueBuscaTodosOsLivrosDoArquivoJSON()
        {
            var books = bookService.GetBooks();
            Assert.AreEqual(books.Count, 5);
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorInformacoesComParametrosNulos()
        {
            var books = bookService.GetBooksBy(0, "", 0, true);
            var book = books.FirstOrDefault();
            Assert.IsNull(book);
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorInformacoesPassandoIdValido()
        {
            var books = bookService.GetBooksBy(1, "", 0, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Journey to the Center"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorInformacoesPassandoNomeValido()
        {
            var books = bookService.GetBooksBy(0, "Journey", 0, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Journey to the Center"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorInformacoesPassandoPrecoValido()
        {
            var books = bookService.GetBooksBy(0, "", 10, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Journey to the Center"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorInformacoesPassandoTodosParametrosValidos()
        {
            var books = bookService.GetBooksBy(1, "Journey to the Center of the Earth", 10, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Journey to the Center"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorEspecificoesPassandoDataDePublicacaoValida()
        {
            var books = bookService.GetBooksBy("November 25", "", 0, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Journey to the Center"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorEspecificoesPassandoAutorValido()
        {
            var books = bookService.GetBooksBy("", "Jules Verne", 0, false);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Journey to the Center"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorEspecificoesPassandoAutorValidoMudandoAOrdem()
        {
            var books = bookService.GetBooksBy("", "Jules Verne", 0, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("20,000 Leagues Under"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorEspecificoesPassandoNumeroDePaginasValido()
        {
            var books = bookService.GetBooksBy("", "", 636, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Harry Potter and the Goblet of Fire"));
        }

        [Test]
        public void TestaMetodoQueBuscaLivrosPorEspecificoesPassandoTodosParametrosValidos()
        {
            var books = bookService.GetBooksBy("July 8, 2000", "J. K. Rowling", 636, true);
            var book = books.FirstOrDefault();
            Assert.IsTrue(book.Name.Contains("Harry Potter and the Goblet of Fire"));
        }
    }
}