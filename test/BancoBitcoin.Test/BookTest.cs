using BancoBitcoin.Application.Interface;
using BancoBitcoin.Application.Service;
using BancoBitcoin.Domain.Repository;
using BancoBitcoin.Repository.Entity;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class BookTest
    {
        // MENSAGEM PARA O AVALIADOR
        // Raramente fa�o teste de reposit�rio, a n�o ser que tenha alguma regra(no caso da prova, utilizei o predicate builder para montar as condicionais), 
        // ou que tenho que comparar dados retornados.
        // No m�ximo que testo a camada de reposit�rio, s�o os mapeamentos do nHibernate, utilizando o PersistenceSpecification.
        // Instanciei a classe concreta de reposit�rio, porque n�o irei utilizar um injetor de depend�ncia no projeto de Teste
        // igual utilizei na aplica��o
        // Utilizo mais o Faker.NET para gerar dados aleat�rios, o Builder pattern para construir objetos complexos, para testar o modelo rico tamb�m. 
        // E por fim, Moq para simular um reposit�rio ou uma service, que n�o � o caso desse teste

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