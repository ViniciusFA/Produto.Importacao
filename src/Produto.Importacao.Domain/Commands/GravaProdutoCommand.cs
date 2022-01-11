using Produto.Importacao.Domain.Entities;
using Produto.Importacao.Domain.Validations.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Importacao.Domain.Commands
{
    public class GravaProdutoCommand //: Command<ResponseDto<RetornoSucessoDTO>>
    {
        public ProdutoEntity Produto { get; set; }

       // public override bool IsValid()
        //{
            //var ValidationResult = new GravaProdutoValidation().Validate(this);
            //return ValidationResult.IsValid;
        //}
    }
}
