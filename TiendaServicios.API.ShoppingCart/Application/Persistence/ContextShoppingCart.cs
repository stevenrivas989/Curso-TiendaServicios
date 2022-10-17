using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.ShoppingCart.Application.Model;

namespace TiendaServicios.API.ShoppingCart.Application.Persistence
{
    public class ContextShoppingCart : DbContext
    {
        public ContextShoppingCart(DbContextOptions<ContextShoppingCart> dbContextOptions):base(dbContextOptions) { }

        public DbSet<SessionCart> SessionCart { get; set; }
        public DbSet<SessionCartDetail> SessionCartDetail { get; set; } 
    }
}
