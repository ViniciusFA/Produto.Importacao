using Produto.Importacao.Domain.Interfaces.Queries;
using Produto.Importacao.Domain.Interfaces.Repositories;
using Produto.Importacao.Domain.Validations.Queries;
using Produto.Importacao.DTO;
using Produto.Importacao.DTO.Produto;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Produto.Importacao.Domain.Queries
{
    public class QueryGetImports : IQueryGetImports
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public QueryGetImports(
            ILogger<QueryGetImports> logger,
            IProdutoRepository repository,
            IMapper mapper 
        ) 
        {
            _repository = repository;
            _mapper     = mapper;
            _logger = logger;
        }

        public ResponseDTO<IList<ProdutoDTO>> GetAllImportsAsync()
        {
            var response = new ResponseDTO<IList<ProdutoDTO>>();

            try
            {
                var retorno = _repository.GetAllImportsAsync();
                response.Results = _mapper.Map<IList<ProdutoDTO>>(retorno);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, MethodBase.GetCurrentMethod().DeclaringType.FullName, null);
            }

            return response;
        }

        public ResponseDTO<ProdutoDTO> GetImportByIdAsync(FilterProdutoDTO filterProduto)
        {
            var response = new ResponseDTO<ProdutoDTO>();

            try
            {
                var responseValidation = new QueryGetImportsValidation().Validate(filterProduto);
                if (!responseValidation.IsValid)
                {
                    //criar método NotifyValidationErrors
                    //NotifyValidationErrors(GetType().Name, responseValidation);
                    return response;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MethodBase.GetCurrentMethod().DeclaringType.FullName, null);
                //criar método NotifyValidationErrors
                // NotifyException(ex);
            }

            var retorno =  _repository.GetImportsByIdAsync(filterProduto.Id);
            response.Results = _mapper.Map<ProdutoDTO>(retorno);

            return response;
        }

    }
}
