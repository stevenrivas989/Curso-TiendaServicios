using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.API.Autor.Aplication.Model
{
    public class AcademicDegree
    {
        [Key]
        public int IdAcademicDegree { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? DegreeDate { get; set; }
        public int AuthorLibroId { get; set; }
        public BookAuthor Author { get; set; }
        public string AcademicDegreeGuid { get; set; }
    }
}
