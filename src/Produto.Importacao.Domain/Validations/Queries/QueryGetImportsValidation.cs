using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Importacao.Domain.Validations.Queries
{
    internal class QueryGetImportsValidation : BaseProdutoDTOValidation
    {
        public QueryGetImportsValidation()
        {
            ValidateAllImports();

            ValidateImportById();
        }
    }
}
