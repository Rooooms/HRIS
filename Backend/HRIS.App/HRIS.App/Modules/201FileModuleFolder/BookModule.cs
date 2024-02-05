using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class BookModule
    {
        public static async void AddBookEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Book");

            group.MapGet("/", async (IBookService bookService) => Results.Ok(await bookService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IBookService bookService) => {

                var book = await bookService.GetById(id);

                if (book == null) return Results.NotFound();

                return Results.Ok(book);
            });
           
            group.MapPost("/", async (BookRequest request, IBookService bookService) =>
            {
                var newBook = await bookService.Create(request);
                return Results.Created($"api/Company/{newBook.Id}", newBook);
            });
            group.MapPut("/{id:Guid}", async (Guid id, BookRequest request, IBookService bookService) => {

                var book = await bookService.Update(id, request);
                return Results.Ok(book);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IBookService bookService) =>
            {
                var success = await bookService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
