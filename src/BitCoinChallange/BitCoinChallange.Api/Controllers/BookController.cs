using BitCoinChallange.Api.Controllers.Common;
using BitCoinChallange.Application.Interfaces;
using BitCoinChallange.Application.ViewModels;
using BitCoinChallange.Domain.Kernel.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BitCoinChallange.Api.Controllers
{
	[Produces("application/json")]
	[ApiController]
	public class BookController : BaseApiController
	{
		private readonly IBookQueryService _bookService;

		public BookController(IBookQueryService bookService, INotificationHandler<Notification> notifications) : base(notifications)
		{
			_bookService = bookService;
		}

		/// <summary>
		/// Busca de livro por filtro,
		/// para obter resultado informe ao menos 1 filtro
		/// </summary>
		/// <param name="filter"></param>
		/// <remarks>
		/// Para utilizar o filtro siga as instruções abaixo:
		/// 
		/// 1 - Filtro por nome (Name):
		/// - Este filtro permite filtrar pelo nome do livro.
		/// 
		/// 2 - Ordenação (Ordering):
		/// - é possível ordenar seu resultado por preço preenchendo o campo com ASC ou DESC.
		/// 
		/// 3 - Specificações do livro(Specifications):
		/// - Neste filtro é possivel utilizar a combinação das especificações para buscar os dados, as opção são:
		/// publicação(OriginallyPublished), autor(Author), Ilustrador(Illustrator)* e gênero(Genre)*.
		///
		/// (* os filtros por gênero e ilustrador podem ser adicionados mais de 1, porém este filtro verifica o nome exato na busca.)
		/// </remarks>
		/// <returns>Retorna o livro ou livros que estão dentro dos critérios da busca.</returns>
		/// <response code="200">Consulta efetuada com sucesso</response>
		/// <response code="400">erro nos critérios de busca</response>
		[HttpGet]
		[AllowAnonymous]
		[Route("books")]
		[ProducesResponseType(typeof(BookFilterViewModel), 200)]
		[ProducesResponseType(typeof(Notification), 400)]
		public async Task<IActionResult> Get([FromQuery] BookFilterViewModel filter)
		{
			if (!ModelState.IsValid)
			{
				NotifyModelStateErrors();
			}
			var customerViewModel = await _bookService.GetByFilter(filter);
			return Response(customerViewModel);
		}
	}
}
