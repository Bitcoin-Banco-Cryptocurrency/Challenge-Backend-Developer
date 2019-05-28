using MediatR;
using System;

namespace BitCoinChallange.Domain.Kernel.Events
{
	public abstract class Event : Message, INotification
	{
		public DateTime TimeEvent { get; private set; }

		protected Event()
		{
			TimeEvent = DateTime.Now;
		}
	}
}
