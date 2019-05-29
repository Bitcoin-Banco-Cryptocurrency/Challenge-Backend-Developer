using BitCoinChallange.Domain.Kernel.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BitCoinChallange.Api.Controllers.Common
{
	public abstract class BaseApiController : ControllerBase
	{
		private readonly NotificationHandler _notifications;

		public BaseApiController(INotificationHandler<Notification> notifications)
		{
			_notifications = (NotificationHandler)notifications;
		}
		protected IEnumerable<Notification> Notifications => _notifications.GetNotifications();

		protected bool IsValidOperation()
		{
			return (!_notifications.HasNotifications());
		}

		protected new IActionResult Response(object result = null)
		{
			if (IsValidOperation())
			{
				return Ok(new
				{
					success = true,
					data = result
				});
			}

			return BadRequest(new
			{
				success = false,
				errors = _notifications.GetNotifications().Select(n => n.Value)
			});
		}

		protected void NotifyModelStateErrors()
		{
			var erros = ModelState.Values.SelectMany(v => v.Errors);
			foreach (var erro in erros)
			{
				var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
				NotifyError(string.Empty, erroMsg);
			}
		}

		protected void NotifyError(string code, string message)
		{
			_notifications.Handle(new Notification(code, message), new CancellationToken(true));
		}
	}
}
