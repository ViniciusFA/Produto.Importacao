using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Produto.Importacao.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Mapper
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Mediator
        /// </summary>
        protected readonly IMediator _mediator;

        /// <summary>
        /// Controller base para padronizar chamadas
        /// </summary>
        /// <param name="mapper">Instância do Mapper</param>
        /// <param name="mediator">Instância do mediator</param>
        protected BaseController(IMapper mapper, IMediator mediator) 
        {
        }
    }
}
