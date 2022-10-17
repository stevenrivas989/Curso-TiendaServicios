using FluentValidation;
using MediatR;
using TiendaServicios.API.Book.Application.Model;
using TiendaServicios.API.Book.Application.Persistence;

namespace TiendaServicios.API.Book.Application.Business
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime PublishDate { get; set; }
            public Guid? BookAuthor { get; set; }

        }

        public class ValidationExecute : AbstractValidator<Execute>
        {
            public ValidationExecute()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublishDate).NotEmpty();
                RuleFor(x => x.BookAuthor).NotEmpty();
            }

        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ContextLibrary _contextLibrary;

            public Handler(ContextLibrary contextLibrary)
            {
                _contextLibrary = contextLibrary;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new MaterialLibrary
                {
                    Title = request.Title,
                    PublishDate = request.PublishDate,
                    BookAuthor = request.BookAuthor
                };

                _contextLibrary.MaterialLibrary.Add(book);
                return await _contextLibrary.SaveChangesAsync() > 0 
                    ? Unit.Value : throw new Exception("Could not insert the book.");
            }
        }
    }
}
