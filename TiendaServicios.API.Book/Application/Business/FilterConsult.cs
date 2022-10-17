using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Book.Application.Business.DTO;
using TiendaServicios.API.Book.Application.Persistence;

namespace TiendaServicios.API.Book.Application.Business
{
    public class FilterConsult
    {
        public class UnicBook : IRequest<MaterialLibraryDTO>
        {
            public Guid? BookId { get; set; }


        }

        public class Handler : IRequestHandler<UnicBook, MaterialLibraryDTO>
        {
            private readonly ContextLibrary _contextLibrary;
            private readonly IMapper _mapper;

            public Handler(ContextLibrary contextLibrary, IMapper mapper)
            {
                _contextLibrary = contextLibrary;
                _mapper = mapper;
            }

            public async Task<MaterialLibraryDTO> Handle(UnicBook request, CancellationToken cancellationToken)
            {
                return  _mapper.Map<MaterialLibraryDTO>(await _contextLibrary.MaterialLibrary.FirstOrDefaultAsync(
                    x=> x.IdMaterialLibrary == request.BookId));
            }
        }

    }
}
