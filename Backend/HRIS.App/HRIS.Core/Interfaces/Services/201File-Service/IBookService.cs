using HRIS.Core.Entities;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<BookResponse>> GetAll();

        Task<BookResponse?> GetById(Guid id);

        Task<BookResponse> Create(BookRequest request);

        Task<BookResponse> Update(Guid id, BookRequest request);

        Task<bool> Delete(Guid id);
        
    }
}
