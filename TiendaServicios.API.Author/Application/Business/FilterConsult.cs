using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Author.Aplication.Business.DTO;
using TiendaServicios.API.Author.Aplication.Model;
using TiendaServicios.API.Author.Aplication.Persistence;

namespace TiendaServicios.API.Author.Aplication.Business
{
    public class FilterConsult
    {
        public class UnicAuthor : IRequest<BookAuthorDTO>
        {
            public string GuidBookAuthor { get; set; }

            public class Handler : IRequestHandler<UnicAuthor, BookAuthorDTO>
            {
                private readonly ContextAuthor _contextAuthor;
                private readonly IMapper _mapper;

                public Handler(ContextAuthor contextAuhor, IMapper mapper)
                {
                    _contextAuthor = contextAuhor;
                    _mapper = mapper;
                }
                public async Task<BookAuthorDTO> Handle(UnicAuthor request, CancellationToken cancellationToken)
                {
                    var author = await _contextAuthor.BookAuthor.Where(a => a.BookAuthorGuid == request.GuidBookAuthor).FirstOrDefaultAsync();
                    if (author == null)
                        throw new Exception("The author not exists");

                    return _mapper.Map<BookAuthorDTO>(author);

                
                }
            }
        }
    }
}
