using HRIS.Core.Entities.UserEntities;
using HRIS.Core.Models.Requests.User_Request;
using HRIS.Core.Models.Responses.User_Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services.User_Service
{
    public interface IUserService
    {
        Task<CheckLoggedResponse> CheckLogged(ClaimsPrincipal user);

        Task<UserResponse> RegisterUser(UserRequest request);

        Task<bool> DeleteUser(Guid id);

        Task<List<UserResponse>> GetAll();

        Task<UserResponse> GetById(Guid id);

        //Task<(string Token, User User)?> LoginUser(LoginRequest request, HttpContext context);
        Task<LoginResponse> UserLogin(LoginRequest request);
        //Task<LoginResponseResult> UserLogin(LoginRequest request);

        Task<UserResponse>Update (Guid id, UpdateUserRequest request);
        Task Logout();
    }
}
