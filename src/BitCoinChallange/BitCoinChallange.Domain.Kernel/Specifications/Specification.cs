using System;
using System.Linq.Expressions;

namespace BitCoinChallange.Domain.Kernel.Specifications
{
	public abstract class Specification<T1, T2>
	{
		public abstract Expression<Func<T1, T2, bool>> ToExpression();

		public bool IsSatisfiedBy(T1 entity, T2 filter)
		{
			Func<T1, T2, bool> predicate = ToExpression().Compile();
			return predicate(entity, filter);
		}
	}
}
