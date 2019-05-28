using System;
using System.Collections.Generic;
using System.Text;

namespace BitCoinChallange.Domain.Kernel.Queries
{
	public interface IPageQueryResult<TEntity> where TEntity : class
	{
		/// <summary>
		/// retorno da coleção de items
		/// </summary>
		IReadOnlyList<TEntity> Items { get; }
		/// <summary>
		/// total de items
		/// </summary>
		int TotalItems { get; }
		/// <summary>
		/// tamanho da página
		/// </summary>
		int PageSize { get; }
		/// <summary>
		/// Total de páginas
		/// </summary>
		int TotalPages { get; }
		/// <summary>
		/// Página atual. entre 1 e n
		/// </summary>
		int Page { get; }
	}
}
