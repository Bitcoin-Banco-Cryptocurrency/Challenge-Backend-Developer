using BitCoinChallange.Domain.Queries;
using FluentValidation;

namespace BitCoinChallange.Domain.Validations
{
	public abstract class BookValidation<T> : AbstractValidator<T> where T : BookQueryRequest
	{

		protected void ValidateOrdering()
		{
			RuleFor(c => c.Ordering)
				.NotEmpty()
				.NotNull()
				.Must((m, valid) => valid == "ASC" || valid == "DESC")
				.WithMessage("Informe qual a forma de ordenação (ASC ou DESC)");
		}

	}
}
