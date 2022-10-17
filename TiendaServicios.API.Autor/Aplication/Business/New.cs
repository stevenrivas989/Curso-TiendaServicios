using MediatR;
using TiendaServicios.API.Autor.Aplication.Model;
using TiendaServicios.API.Autor.Aplication.Persistence;

namespace TiendaServicios.API.Autor.Aplication.Business
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly ContextAuthor _contextAuthor;

            public Handler(ContextAuthor contextAuthor)
            {
                _contextAuthor = contextAuthor;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var bookAuthor = new BookAuthor
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Bithdate = request.BirthDate,
                    BookAuthorGuid = Guid.NewGuid().ToString()
                };

                _contextAuthor.BookAuthor.Add(bookAuthor);
                var value = await _contextAuthor.SaveChangesAsync();
                if(value>0)
                    return Unit.Value;

                throw new Exception("Could not insert the author of the book.");


            }
        }


    }
}
