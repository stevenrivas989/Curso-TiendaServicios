using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Author.Aplication.Business.DTO;
using TiendaServicios.API.Author.Aplication.Model;
using TiendaServicios.API.Author.Aplication.Persistence;

namespace TiendaServicios.API.Author.Aplication.Business
{
    public class Consult
    {
        public class ListAuthor : IRequest<List<BookAuthorDTO>>
        {

        }

        public class Handler : IRequestHandler<ListAuthor, List<BookAuthorDTO>>
        {

            private readonly ContextAuthor _contextAuthor;
            private readonly IMapper _mapper;

            public Handler(ContextAuthor contextAuthor, IMapper mapper)
            {
                _contextAuthor = contextAuthor;
                _mapper = mapper;
            }

            public async Task<List<BookAuthorDTO>> Handle(ListAuthor request, CancellationToken cancellationToken)
            {
                var authors = await _contextAuthor.BookAuthor.ToListAsync();
                var authorsDTO = _mapper.Map<List<BookAuthorDTO>>(authors);
                return authorsDTO;
            }
        }
    }
}
