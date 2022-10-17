using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.API.Autor.Aplication.Model
{
    public class BookAuthor
    {
        [Key]
        public int IdBookAuthot { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Bithdate { get; set; }
        public ICollection<AcademicDegree> ListAcademicDegree { get; set; }
        public string BookAuthorGuid { get; set; }

    }
}
