using BitCoinChallange.Domain.Queries;
using FluentValidation;

namespace BitCoinChallange.Domain.Validations
{
	public abstract class BookValidation<T> : AbstractValidator<T> where T : BookQueryRequest
	{

		protected void ValidateOrdering()
		{
			RuleFor(c => c.Ordering)
				.Must((m, valid) => valid == "ASC" || valid == "DESC")
				.When(w=> !string.IsNullOrEmpty(w.Ordering) && !string.IsNullOrWhiteSpace(w.Ordering))
				.WithMessage("Informe qual a forma de ordenação (ASC ou DESC), a ordenação é feita por preço");
		}

	}
}
