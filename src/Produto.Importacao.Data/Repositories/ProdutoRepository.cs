using Produto.Importacao.Data.Context;
using Produto.Importacao.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Produto.Importacao.DTO.Produto;

namespace Produto.Importacao.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _produtoContext;

        public ProdutoRepository(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public IEnumerable<ProdutoDTO> GetAllImportsAsync()
        {
            var listaRetornoDB = _produtoContext.Produtos
                                                .OrderBy(x => x.DataEntrega)
                                                .ToList();

            List<ProdutoDTO> listProdutoDTO = new List<ProdutoDTO>();

            if (listaRetornoDB.Count > 0)
            {
                for (int i = 0; i < listaRetornoDB.Count; i++)
                {
                    listProdutoDTO.Add(
                         new ProdutoDTO()
                         {
                             IdProduto = listaRetornoDB[i].Id,
                             DataEntrega = DateTime.Parse(listaRetornoDB[i].DataEntrega.ToString()),
                             NomeProduto = listaRetornoDB[i].NomeProduto.ToString(),
                             QtdProduto = listaRetornoDB[i].QtdProduto,
                             ValorUnitario = listaRetornoDB[i].ValorUnitario,
                             ValorTotalPorId = listaRetornoDB[i].ValorUnitario * listaRetornoDB[i].QtdProduto
                         }
                    );
                }
            }

            return listProdutoDTO;
        }

        public ProdutoDTO GetImportsByIdAsync(int id)
        {
            var result = _produtoContext.Produtos.Where(x => x.Id == id).FirstOrDefault();

            return result != null ? 
                new ProdutoDTO()
                {
                    IdProduto = result.Id,
                    DataEntrega = DateTime.Parse(result.DataEntrega.ToString()),
                    NomeProduto = result.NomeProduto.ToString(),
                    QtdProduto = result.QtdProduto,
                    ValorUnitario = result.ValorUnitario,
                    ValorTotalPorId = result.ValorUnitario * result.QtdProduto
                } 
                :new ProdutoDTO();          
        }
    }
}
