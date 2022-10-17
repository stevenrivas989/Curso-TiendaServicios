using AutoMapper;
using TiendaServicios.API.Author.Aplication.Model;

namespace TiendaServicios.API.Author.Aplication.Business.DTO
{
    public class BookAuthorDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Bithdate { get; set; }
        public string BookAuthorGuid { get; set; }
    }

    public class BookAuthorProfile : Profile
    {
        public BookAuthorProfile()
        {
            CreateMap<BookAuthorDTO, BookAuthor>()
                .ReverseMap();
        }
    }
}
