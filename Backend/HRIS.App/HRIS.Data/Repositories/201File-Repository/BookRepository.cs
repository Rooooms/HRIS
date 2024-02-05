using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Book newBook)
        {
            _context.Books.Add(newBook);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public Task<List<Book>> GetAll()
        {
            return _context.Books.OrderBy(p => p.BookName).ToListAsync();
        }

        public Task<Book?> GetById(Guid id)
        {
            return _context.Books.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
