using Produto.Importacao.DTO;
using Produto.Importacao.DTO.Produto;
using System.Collections.Generic;

namespace Produto.Importacao.Domain.Interfaces.Queries
{
    public interface IQueryGetImports
    {
        ResponseDTO<IList<ProdutoDTO>> GetAllImportsAsync();
        ResponseDTO<ProdutoDTO> GetImportByIdAsync(FilterProdutoDTO filterProduto);
    }
}
