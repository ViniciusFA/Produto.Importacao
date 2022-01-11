using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Produto.Importacao.Domain.Interfaces.Queries;
using Produto.Importacao.DTO.Error;
using Microsoft.Extensions.Logging;
using Produto.Importacao.DTO.Produto;
using Produto.Importacao.DTO;
using Produto.Importacao.Domain.Commands;

namespace Produto.Importacao.WebAPI.Controllers
{
    /// <summary>
    /// Controlador principal do Produto
    /// </summary>
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IQueryGetImports _queryGetImports;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        /// <param name="queryGetImports"></param>
        public ProdutosController(
            IMapper mapper,
            ILogger<ProdutosController> logger,
            IMediator mediator,
            IQueryGetImports queryGetImports
            ) 
            : base(mapper , mediator)
        {
            _logger = logger;
            _queryGetImports = queryGetImports;
        }

        /// <summary>
        /// Recupera todos os produtos importados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public  ActionResult<ResponseDTO<IList<ProdutoDTO>>> GetAllImportsAsync()
        {
            try
            {
                 _logger.LogInformation($"[{nameof(ProdutosController)}]:[{nameof(GetAllImportsAsync)}] - inicializando execucao.");

                return  _queryGetImports.GetAllImportsAsync();
            }
            finally
            {
                _logger.LogInformation($"[{nameof(ProdutosController)}]:[{nameof(GetAllImportsAsync)}] - finalizando execucao.");
            }
        }

        /// <summary>
        /// Recupera o produto importado conforme o id enviado
        /// </summary>
        /// <param name="id">Código do produto</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<ResponseDTO<ProdutoDTO>> GetImportById(int id)
        {
            try
            {
                 _logger.LogInformation($"[{nameof(ProdutosController)}]:[{nameof(GetAllImportsAsync)}] - inicializando execucao.");

                var ProdutoIdFilter = new FilterProdutoDTO
                {
                    Id = id
                };

                return  _queryGetImports.GetImportByIdAsync(ProdutoIdFilter);
            }
            finally
            {
                _logger.LogInformation($"[{nameof(ProdutosController)}]:[{nameof(GetAllImportsAsync)}] - finalizando execucao.");
            }
        }

        /// <summary>
        /// Persiste Produto na base de dados
        /// </summary>
        /// <param name="produto"></param>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public /*async*/ Task<object> Insert([FromBody] GravaProdutoCommand produto)
        {
            return _mediator.Send(produto, default);
        }

    }
}
