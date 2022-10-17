using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.Author.Aplication.Business;
using TiendaServicios.API.Author.Aplication.Business.DTO;
using TiendaServicios.API.Author.Aplication.Model;

namespace TiendaServicios.API.Author.Aplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookAuthorDTO>>> GetAuthors()
        {
            return await _mediator.Send(new Consult.ListAuthor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookAuthorDTO>> GetAuthor(string id)
        {
            return await _mediator.Send(new FilterConsult.UnicAuthor{ GuidBookAuthor = id });
        }
    }
}
