using HRIS.Core.Entities.Leave_Entities;
using HRIS.Core.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories.Leaves_Repositories
{
    public interface ILeaveRepository
    {
        Task<List<LeaveEntities>> GetAll();

        Task<LeaveEntities?> GetById(Guid id);
        void Add(LeaveEntities newLeave);

        void Delete(LeaveEntities leave);

        Task<int> SaveChangesAysnc();
        Task<List<LeaveEntities>> GetLeavesByEmployeeNumber(int employeeNumber);


    }
}
