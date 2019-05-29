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
	public class BookController : BaseApiController
	{
		private readonly IBookQueryService _bookService;

		public BookController(IBookQueryService bookService, INotificationHandler<Notification> notifications) : base(notifications)
		{
			_bookService = bookService;
		}


		[HttpGet]
		[AllowAnonymous]
		[Route("books")]
		public async Task<IActionResult> Get(BookFilterViewModel filter)
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
