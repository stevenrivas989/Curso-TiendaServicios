using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.API.ShoppingCart.Application.Model
{
    public class SessionCart
    {
        [Key]
        public int IdSessionCart { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<SessionCartDetail> ListSessionCartDetails { get; set; }
    }
}
