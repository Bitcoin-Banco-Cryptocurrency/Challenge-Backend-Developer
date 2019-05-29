using BitCoinChallange.Domain.Queries;

namespace BitCoinChallange.Domain.Validations
{
	public class BookQueryValidation : BookValidation<BookQueryRequest>
	{
		public BookQueryValidation()
		{
			ValidateOrdering();
		}
	}
}
