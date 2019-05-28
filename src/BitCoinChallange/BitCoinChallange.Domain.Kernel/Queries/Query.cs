using BitCoinChallange.Domain.Kernel.Events;
using FluentValidation.Results;
using MediatR;
using System;

namespace BitCoinChallange.Domain.Kernel.Queries
{
	public abstract class Query<TModel> : Message where TModel : class, IRequest<PageResponse<TModel>>
	{
		public DateTime TimeQuery { get; private set; }

		public ValidationResult ValidationResult { get; set; }

		protected Query()
		{
			TimeQuery = DateTime.Now;
		}

		public abstract bool IsValid();
	}
}
