using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Importacao.DTO.Error
{
    public sealed class ErrorResponse
    {
        public ErrorResponse() { }

        public string Source { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string InnerException { get; set; }

    }
}
