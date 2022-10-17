using TiendaServicios.API.ShoppingCart.Application.Service.Remote;

namespace TiendaServicios.API.ShoppingCart.Application.Service
{
    public interface IMaterialLibraryService
    {
        Task<(bool isSuccess, MaterialLibraryRemote book, string errorMessage)> GetBook(Guid idBook);

    }
}
