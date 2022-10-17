using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.API.Book.Application.Business.DTO;
using TiendaServicios.API.Book.Application.Model;

namespace TiendaServicios.API.Test.Book
{
    internal class MappingTest : Profile
    {

        public MappingTest()
        {
            CreateMap<MaterialLibraryDTO, MaterialLibrary>()
                   .ReverseMap();
        }
    }
}
