using HRIS.Core.Entities.UserEntities;
using HRIS.Core.Interfaces.Services;
using HRIS.Core.Interfaces.Services.EmailSender;
using HRIS.Core.Interfaces.Services.Leave_Service;
using HRIS.Core.Interfaces.Services.User_Service;
using HRIS.Service.Services;
using HRIS.Service.Services.Leaves_Service;
using HRIS.Service.Services.User_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Service
{
    public static class Bootstrapper
    {
        public static IServiceCollection HRISService(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<IEmployeeDetailService,EmployeeDetailsService>();
            services.AddTransient<IEducationalBGService, EducationalBGService>();
            services.AddTransient<IEmploymentBackgroundService, EmploymentBackgroundService>();
            services.AddTransient<ISalaryService, SalaryService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IRequirementService, RequirementService>();
            services.AddTransient<IPaymastService, PaymastService>();
            services.AddTransient<IBenefitService, BenefitService>();
            services.AddTransient<IApexMerchService, ApexMerchService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILeaveService, LeaveService>();
            services.AddTransient<IEmailService,EmailService>();

            //services.AddTransient<JwtMiddleware>(sp =>
            //{
            //    var requestDelegate = sp.GetRequiredService<RequestDelegate>();
            //    var configuration = sp.GetRequiredService<IConfiguration>();
            //    var logger = sp.GetRequiredService<ILogger<JwtMiddleware>>();
            //    return new JwtMiddleware(requestDelegate, configuration, logger) ;
            //});
            return services;
        }
    }
}
