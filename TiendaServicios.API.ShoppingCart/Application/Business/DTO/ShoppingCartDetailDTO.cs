namespace TiendaServicios.API.ShoppingCart.Application.Business.DTO
{
    public class ShoppingCartDetailDTO
    {
        public Guid? IdBook { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime? PublishDate { get; set; }

    }
}
