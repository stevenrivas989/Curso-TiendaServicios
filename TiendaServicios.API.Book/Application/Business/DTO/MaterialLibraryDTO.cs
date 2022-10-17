using AutoMapper;
using TiendaServicios.API.Book.Application.Model;

namespace TiendaServicios.API.Book.Application.Business.DTO
{
    public class MaterialLibraryDTO
    {
        public Guid? IdMaterialLibrary { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid? BookAuthor { get; set; }

        public class BookAuthorProfile : Profile
        {
            public BookAuthorProfile()
            {
                CreateMap<MaterialLibraryDTO, MaterialLibrary>()
                    .ReverseMap();
            }
        }
    }
}
