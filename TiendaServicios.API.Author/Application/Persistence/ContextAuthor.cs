using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Author.Aplication.Model;

namespace TiendaServicios.API.Author.Aplication.Persistence
{
    public class ContextAuthor : DbContext
    {

        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options) => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<AcademicDegree> AcademicDegree { get; set; }
    }
}
