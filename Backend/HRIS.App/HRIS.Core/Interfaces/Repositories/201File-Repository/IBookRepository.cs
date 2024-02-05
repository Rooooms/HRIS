using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book?> GetById(Guid id);
        void Add(Book newBook);

        void Delete(Book book);

        Task<int> SaveChangesAysnc();
    }
}
