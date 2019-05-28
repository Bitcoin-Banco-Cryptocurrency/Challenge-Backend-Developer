using BitCoinChallange.Domain.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCoinChallange.Domain.Kernel.Notifications
{
	public class Notification : Event
	{
		public string Key { get; private set; }

		public string Value { get; private set; }

		public Notification(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}
