using BitCoinChallange.Domain.Kernel.Events;
using System;

namespace BitCoinChallange.Domain.Kernel.Notifications
{
	public class Notification : Event
	{
		public string Key { get; private set; }

		public string Value { get; private set; }

		public Guid IdMassage { get; private set; }

		public Notification(string key, string value)
		{
			IdMassage = Guid.NewGuid();
			Key = key;
			Value = value;
		}
	}
}
