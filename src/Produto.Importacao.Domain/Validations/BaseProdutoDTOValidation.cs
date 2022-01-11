using FluentValidation;
using Produto.Importacao.DTO.Produto;

namespace Produto.Importacao.Domain.Validations
{
    internal abstract class BaseProdutoDTOValidation : AbstractValidator<FilterProdutoDTO>
    {
        protected void ValidateAllImports() { }
        protected void ValidateImportById() { }
    }
}
