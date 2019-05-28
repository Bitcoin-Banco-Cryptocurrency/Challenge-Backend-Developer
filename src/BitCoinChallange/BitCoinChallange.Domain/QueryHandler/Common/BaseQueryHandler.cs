using BitCoinChallange.Domain.Kernel.Handlers;
using BitCoinChallange.Domain.Kernel.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using BitCoinChallange.Domain.Kernel.Queries;

namespace BitCoinChallange.Domain.QueryHandler.Common
{
	public class BaseQueryHandler
	{
		private readonly IMediatorHandler _memoryBus;
		private readonly NotificationHandler _notifications;

		public BaseQueryHandler(IMediatorHandler memoryBus, INotificationHandler<Notification> notifications)
		{
			_notifications = (NotificationHandler)notifications;
			_memoryBus = memoryBus;
		}

		protected void NotifyValidationErrors(Query message)
		{
			foreach (var error in message.ValidationResult.Errors)
			{
				_memoryBus.RaiseEvent(new Notification(message.MessageType, error.ErrorMessage));
			}
		}
	}
}
