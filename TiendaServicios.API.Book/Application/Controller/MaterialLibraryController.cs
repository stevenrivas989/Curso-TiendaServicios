using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.Book.Application.Business;
using TiendaServicios.API.Book.Application.Business.DTO;

namespace TiendaServicios.API.Book.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialLibraryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialLibraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialLibraryDTO>>> GetBooks(){

            return await _mediator.Send(new Consult.ListBooks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialLibraryDTO>> GetBook(string id)
        {
            return await _mediator.Send(new FilterConsult.UnicBook { BookId = Guid.Parse(id) });
        }

    }
}
