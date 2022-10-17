using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.ShoppingCart.Application.Business.DTO;
using TiendaServicios.API.ShoppingCart.Application.Persistence;
using TiendaServicios.API.ShoppingCart.Application.Service;

namespace TiendaServicios.API.ShoppingCart.Application.Business
{
    public class Consult
    {
        public class Execute : IRequest<ShoppingCartDTO>
        {
            public int IdSessionCart { get; set; }
        }

        public class Handler : IRequestHandler<Execute, ShoppingCartDTO>
        {
            private readonly ContextShoppingCart _contextShoppingCart;
            private readonly IMaterialLibraryService _materialLibraryService;

            public Handler(ContextShoppingCart contextShoppingCart, IMaterialLibraryService materialLibraryService)
            {
                _contextShoppingCart = contextShoppingCart;
                _materialLibraryService = materialLibraryService;
            }

            public async Task<ShoppingCartDTO> Handle(Execute request, CancellationToken cancellationToken)
            {
                var sessionCart = await _contextShoppingCart.SessionCart.FirstOrDefaultAsync(x => x.IdSessionCart == request.IdSessionCart);
                if (sessionCart == null)
                    throw new Exception("The cart no exists");

                var cartDetail = await _contextShoppingCart.SessionCartDetail.Where(x => x.SessionCartId == sessionCart.IdSessionCart).ToListAsync();

                if (!cartDetail.Any())
                    throw new Exception("The cart not contain products");

                List<ShoppingCartDetailDTO> listProducts = new();
                foreach (var x in cartDetail)
                {
                    var bookResult = await _materialLibraryService.GetBook(Guid.Parse(x.SelectedProduct));
                    if (bookResult.isSuccess)
                    {
                        var book = bookResult.book;
                        listProducts.Add(new ShoppingCartDetailDTO
                        {
                            //BookAuthor = book.BookAuthor,
                            BookTitle = book.Title,
                            PublishDate = book.PublishDate,
                            IdBook = book.IdMaterialLibrary
                        });
                    }
                }

                return new ShoppingCartDTO
                {
                    IdSessionCart = sessionCart.IdSessionCart,
                    ListProducts = listProducts,
                    SessionCreateDate = sessionCart.CreationDate
                };
            }   
        }
    }
}
