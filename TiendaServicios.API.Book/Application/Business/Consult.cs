using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Book.Application.Business.DTO;
using TiendaServicios.API.Book.Application.Persistence;

namespace TiendaServicios.API.Book.Application.Business
{
    public class Consult
    {
        public class ListBooks : IRequest<List<MaterialLibraryDTO>>
        {

        }

        public class Handler : IRequestHandler<ListBooks, List<MaterialLibraryDTO>>
        {
            private readonly ContextLibrary _contextLibrary;
            private readonly IMapper _mapper;

            public Handler(ContextLibrary contextLibrary, IMapper mapper)
            {
                _contextLibrary = contextLibrary;
                _mapper = mapper;
            }

            public async Task<List<MaterialLibraryDTO>> Handle(ListBooks request, CancellationToken cancellationToken)
            {
                var books = await _contextLibrary.MaterialLibrary.ToListAsync();
                return _mapper.Map<List<MaterialLibraryDTO>>(books);
            }
        }
    }
}
