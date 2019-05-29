using System;
using System.Linq.Expressions;

namespace BitCoinChallange.Domain.Kernel.Specifications
{
	public abstract class Specification<TEntity, T2>
		where TEntity : class
	{
		public abstract Expression<Func<TEntity, T2, bool>> ToExpression();

		public bool IsSatisfiedBy(TEntity entity, T2 filter)
		{
			Func<TEntity, T2, bool> predicate = ToExpression().Compile();
			return predicate(entity, filter);
		}
	}
}
