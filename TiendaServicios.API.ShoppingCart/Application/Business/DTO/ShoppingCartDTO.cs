namespace TiendaServicios.API.ShoppingCart.Application.Business.DTO
{
    public class ShoppingCartDTO
    {
        public int IdSessionCart { get; set; }
        public DateTime? SessionCreateDate { get; set; }
        public List<ShoppingCartDetailDTO> ListProducts { get; set; }

    }
}
