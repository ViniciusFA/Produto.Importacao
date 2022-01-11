using Produto.Importacao.DTO.Produto;
using System.Collections.Generic;

namespace Produto.Importacao.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<ProdutoDTO> GetAllImportsAsync();
        ProdutoDTO GetImportsByIdAsync(int id);
    }
}
