using Microsoft.EntityFrameworkCore;
using Produto.Importacao.Domain.Entities;

namespace Produto.Importacao.Data.Context
{
    public class ProdutoContext :  DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }

        public DbSet<ProdutoEntity> Produtos { get; set; }
    }
}
