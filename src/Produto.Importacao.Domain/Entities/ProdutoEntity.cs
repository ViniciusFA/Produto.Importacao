using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Importacao.Domain.Entities
{
    public class ProdutoEntity
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int QtdProduto { get; set; }
        public float ValorUnitario { get; set; }
    }
}
