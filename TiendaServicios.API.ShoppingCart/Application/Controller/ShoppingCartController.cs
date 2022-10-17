using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.ShoppingCart.Application.Business;
using TiendaServicios.API.ShoppingCart.Application.Business.DTO;

namespace TiendaServicios.API.ShoppingCart.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDTO>> GetShoppingCart(int id)
        {
            return await _mediator.Send(new Consult.Execute {  IdSessionCart = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }
    }
}
