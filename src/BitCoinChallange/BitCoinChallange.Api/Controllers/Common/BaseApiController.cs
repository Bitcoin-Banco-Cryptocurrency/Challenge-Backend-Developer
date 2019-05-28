using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinChallange.Api.Controllers.Common
{
	//public abstract class BaseApiController : ControllerBase
	//{
	//	private readonly NotificationHandler _notifications;

	//	public BaseApiController(INotificationHandler<Notification> notifications)
	//	{
	//		_notifications = (NotificationHandler)notifications;
	//	}
	//	protected IEnumerable<Notification> Notifications => _notifications.GetNotifications();

	//	protected bool IsValidOperation()
	//	{
	//		return (!_notifications.HasNotifications());
	//	}

	//	protected new IActionResult Response(object result = null)
	//	{
	//		if (IsValidOperation())
	//		{
	//			return Ok(new
	//			{
	//				success = true,
	//				tipoRetorno = 1,
	//				data = result
	//			});
	//		}

	//		var status = Notifications.Select(s => s.Key);

	//		if (status.Any(n => n.Equals(HttpStatusCode.OK.ToString())))
	//		{
	//			return Ok(new { success = true, tipoRetorno = 1, data = new { mensagens = _notifications.GetNotifications().Select(n => n.Value) } });
	//		}

	//		if (_notifications.GetNotifications().Any(n => n.Key.Equals(HttpStatusCode.Accepted.ToString())))
	//		{
	//			return Ok(new { success = false, tipoRetorno = 2, data = new { mensagens = _notifications.GetNotifications().Select(n => n.Value) } });
	//		}

	//		if (_notifications.GetNotifications().Any(n => n.Key.Equals(HttpStatusCode.NotFound.ToString())))
	//		{
	//			return NotFound(new { success = false, tipoRetorno = 2, data = new { mensagens = _notifications.GetNotifications().Select(n => n.Value) } });
	//		}

	//		return UnprocessableEntity(new { success = false, data = new { mensagens = _notifications.GetNotifications().Select(n => n.Value) } });
	//	}

	//	protected new IActionResult RetornoListaPaginacao<T>(PageQueryResult<T> result) where T : class
	//	{
	//		var response = new RetornoListaDto<T>();
	//		if (IsValidOperation())
	//		{
	//			response.Status = ResultadoOperacao.Sucesso;
	//			response.TotalRegistros = result.TotalItems;
	//			response.PaginaAtual = result.Page;
	//			response.TamanhoPagina = result.PageSize;
	//			response.Objeto = result.Items.ToList();
	//			return Ok(response);
	//		}
	//		response.Status = ResultadoOperacao.Falha;
	//		return NotFound(response);
	//	}

	//	protected new IActionResult RetornoLista<T>(List<T> result) where T : class
	//	{
	//		var response = new RetornoListaDto<T>();
	//		if (IsValidOperation())
	//		{
	//			response.Status = ResultadoOperacao.Sucesso;
	//			response.Objeto = result;
	//			return Ok(response);
	//		}
	//		response.Status = ResultadoOperacao.Falha;
	//		return NotFound(response);
	//	}

	//	protected void NotifyModelStateErrors()
	//	{
	//		var erros = ModelState.Values.SelectMany(v => v.Errors);
	//		foreach (var erro in erros)
	//		{
	//			var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
	//			NotifyError(string.Empty, erroMsg);
	//		}
	//	}

	//	protected void NotifyError(string code, string message)
	//	{
	//		_notifications.Handle(new Notification(code, message), new CancellationToken(true));
	//	}
	//}
}
