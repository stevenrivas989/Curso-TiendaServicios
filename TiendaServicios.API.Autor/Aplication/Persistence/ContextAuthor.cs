using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Autor.Aplication.Model;

namespace TiendaServicios.API.Autor.Aplication.Persistence
{
    public class ContextAuthor : DbContext
    {

        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options)
        {

        }

        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<AcademicDegree> AcademicDegree { get; set; }
    }
}
