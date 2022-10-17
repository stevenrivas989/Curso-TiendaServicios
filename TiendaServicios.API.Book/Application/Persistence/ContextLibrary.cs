using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Book.Application.Model;

namespace TiendaServicios.API.Book.Application.Persistence
{
    public class ContextLibrary : DbContext
    {
        public ContextLibrary()
        {

        }

        public ContextLibrary(DbContextOptions<ContextLibrary> options) : base(options)
        {

        }

        public virtual DbSet<MaterialLibrary> MaterialLibrary { get; set; }
    }
}
