using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.API.ShoppingCart.Application.Model
{
    public class SessionCartDetail
    {
        [Key]
        public int SessionCartDetailId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string SelectedProduct { get; set; }
        public int SessionCartId { get; set; }
        public SessionCart SessionCart { get; set; }
    }
}
