using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Repositories.Leaves_Repositories;
using HRIS.Core.Interfaces.Repositories.UserRepository;
using HRIS.Data.Repositories;
using HRIS.Data.Repositories._201File_Repository;
using HRIS.Data.Repositories.LeaveRepository;
using HRIS.Data.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data
{
    public static class Bootstrapper
    {
        public static IServiceCollection HRISData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IEmployeeDetailsRepository, EmployeeDetailsRepository>();
            services.AddScoped<IEducationalBGRepository, EducationalBGRepository>();
            services.AddScoped<IEmploymentBackgroundRepository, EmploymentBackgroundRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRequirementRepository, RequirementRepository>();
            services.AddScoped<IPaymastRepository, PaymastRepository>();
            services.AddScoped<IBenefitRepository, BenefitRepository>();
            services.AddScoped<IApexMerchRepository, ApexMerchRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
