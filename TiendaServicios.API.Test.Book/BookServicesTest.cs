using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.API.Book.Application.Business;
using TiendaServicios.API.Book.Application.Business.DTO;
using TiendaServicios.API.Book.Application.Model;
using TiendaServicios.API.Book.Application.Persistence;
using Xunit;
using static TiendaServicios.API.Book.Application.Business.Consult;

namespace TiendaServicios.API.Test.Book
{

    public class BookServicesTest
    {
        private IEnumerable<MaterialLibrary> GetDataTest()
        {
            A.Configure<MaterialLibrary>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.IdMaterialLibrary, () => Guid.NewGuid());

            var list = A.ListOf<MaterialLibrary>(30);
            list[0].IdMaterialLibrary = Guid.Empty;

            return list;

        }

        private Mock<ContextLibrary> CreateContext()
        {
            var dataTest = GetDataTest().AsQueryable();

            var dbSet = new Mock<DbSet<MaterialLibrary>>();
            dbSet.As<IQueryable<MaterialLibrary>>()
                .Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<MaterialLibrary>>()
                .Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<MaterialLibrary>>()
                .Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<MaterialLibrary>>()
                .Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());


            dbSet.As<IAsyncEnumerable<MaterialLibrary>>()
                .Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<MaterialLibrary>(dataTest.GetEnumerator()));

            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<MaterialLibrary>(dataTest.Provider));

            var context = new Mock<ContextLibrary>();
            context.Setup(x=>x.MaterialLibrary).Returns(dbSet.Object);

            return context;

        }

        [Fact]
        public async void GetLibroById()
        {
            var mockContext = CreateContext();

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            }).CreateMapper();

            var request =new FilterConsult.UnicBook();
            request.BookId = Guid.Empty;

            var handler = new FilterConsult.Handler(mockContext.Object, mapper);

            var book = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(book);
            Assert.True(book.IdMaterialLibrary == Guid.Empty);
        }

        [Fact]
        public async void GetBooks()
        {
            //System.Diagnostics.Debugger.Launch();

            var mockContext = CreateContext();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            Handler handler = new(mockContext.Object, mapper);

            ListBooks request = new();

            var list = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(list.Any());
        }

        [Fact]
        public async void SaveBook()
        {
            var options = new DbContextOptionsBuilder<ContextLibrary>()
                .UseInMemoryDatabase(databaseName: "BaseDatosLibro")
                .Options;

            var context = new ContextLibrary(options);

            var request = new New.Execute();

            request.Title = "Prueba Insert";
            request.PublishDate = DateTime.Now;
            request.BookAuthor = Guid.Empty;

            var handler = new New.Handler(context);

            var response = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(response!=null);
             

        }
    }
}
