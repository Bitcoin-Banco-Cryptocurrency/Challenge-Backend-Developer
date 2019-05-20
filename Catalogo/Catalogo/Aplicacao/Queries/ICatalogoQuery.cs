using Catalogo.Aplicacao.Modelos;
using System.Collections.Generic;

namespace Catalogo.Aplicacao.Queries
{
	public interface ICatalogoQuery
	{
		IEnumerable<Book> ObterLivros();
	}
}
