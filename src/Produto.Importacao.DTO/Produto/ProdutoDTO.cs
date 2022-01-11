using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Importacao.DTO.Produto
{
    public class ProdutoDTO
    {
        public int IdProduto { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int QtdProduto { get; set; }
        public float ValorUnitario { get; set; }
        public float ValorTotalPorId { get; set; }
    }
}
