using MediatR;
using TiendaServicios.API.ShoppingCart.Application.Model;
using TiendaServicios.API.ShoppingCart.Application.Persistence;

namespace TiendaServicios.API.ShoppingCart.Application.Business
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime? SessionCreateDate { get; set; }
            public List<string> ListProduct { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ContextShoppingCart _contextShoppingCart;
            public Handler(ContextShoppingCart contextShoppingCart)
            {
                _contextShoppingCart = contextShoppingCart;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var sessionCart = new SessionCart
                {
                    CreationDate = request.SessionCreateDate
                };
                _contextShoppingCart.SessionCart.Add(sessionCart);
                if (await _contextShoppingCart.SaveChangesAsync() == 0)
                    throw new Exception("Could not insert the session cart.");


                request.ListProduct.ForEach(product =>
                {
                    _contextShoppingCart.SessionCartDetail.Add(new SessionCartDetail
                    {
                        CreateDate = request.SessionCreateDate,
                        SelectedProduct = product,
                        SessionCartId = sessionCart.IdSessionCart
                    });

                });

                return await _contextShoppingCart.SaveChangesAsync() > 0
                    ? Unit.Value : throw new Exception("Could not save your shopping cart.");

            }
        }
    }
}
