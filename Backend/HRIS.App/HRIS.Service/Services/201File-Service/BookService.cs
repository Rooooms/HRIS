using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using HRIS.Data;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRIS.Service.Services
{
    public class BookService : IBookService
    {
        public readonly IBookRepository _book;
        public readonly AppDbContext _context;


        public BookService(IBookRepository book, AppDbContext context)
        {
            _book = book;
            _context = context;
        }

        public async Task<BookResponse> Create(BookRequest request)
        {

            var book = request.Adapt<Book>();

           

            _book.Add(book);
            await _book.SaveChangesAysnc();


            var bookDto = book.Adapt<BookResponse>();

            return bookDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var book = await _book.GetById(id);

            if (book == null) return false;

            _book.Delete(book);

            await _book.SaveChangesAysnc();

            return true;
        }

        public async Task<List<BookResponse>> GetAll()
        {
            var book = await _book.GetAll();
            var bookDto = book.Adapt<List<BookResponse>>();

            return bookDto;
        }

        public async Task<BookResponse?> GetById(Guid id)
        {
            var book = await _book.GetById(id);


            var bookDto = book?.Adapt<BookResponse>();

            return bookDto;
        }

        
        public async Task<BookResponse> Update(Guid id, BookRequest request)
        {
            var book = await _book.GetById(id);


            if (book == null) return null;



            request.Adapt(book);

            await _book.SaveChangesAysnc();

            return _book.Adapt<BookResponse>();
        }
    }
}

