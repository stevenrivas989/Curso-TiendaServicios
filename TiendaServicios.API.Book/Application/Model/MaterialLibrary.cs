using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.API.Book.Application.Model
{
    public class MaterialLibrary
    {
        [Key]
        public Guid? IdMaterialLibrary { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid? BookAuthor { get; set; }

    }
}
