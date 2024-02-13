using HRIS.Core.Entities;
using HRIS.Core.Entities.UserEntities;
using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Repositories.UserRepository;
using HRIS.Core.Interfaces.Services.User_Service;
using HRIS.Core.Models.Requests.User_Request;
using HRIS.Core.Models.Responses;
using HRIS.Core.Models.Responses.Leave_Response;
using HRIS.Core.Models.Responses.User_Response;
using HRIS.Data;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRIS.Service.Services.User_Service
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _user;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmployeeDetailsRepository _employeeDetailsRepository;
        private readonly AppDbContext _context;

        public UserService(AppDbContext context, IUserRepository users, IHttpContextAccessor httpContextAccessor, IEmployeeDetailsRepository employeeDetailsRepository)
        {
            _user = users;
            _httpContextAccessor = httpContextAccessor;
            _employeeDetailsRepository = employeeDetailsRepository;
            _context = context;
        }

        //public Task<CheckLoggedResponse> CheckLogged()
        //{
        //    var userSession = new CheckLoggedResponse();


        //    string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        //    Console.WriteLine($"Received token token: {token}");

        //    string userIdString = _httpContextAccessor.HttpContext.Session.GetString("UserId");
        //    if (Guid.TryParse(userIdString, out Guid userId))
        //    {
        //        userSession.Id = userId;
        //    }
        //    userSession.UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName");
        //    string employeeNumberString = _httpContextAccessor.HttpContext.Session.GetString("employeeNumber");
        //    if (int.TryParse(employeeNumberString, out int employeeNumber))
        //    {
        //        userSession.EmployeeNumber = employeeNumber;
        //    }
        //    userSession.UserType = _httpContextAccessor.HttpContext.Session.GetString("UserType");
        //    userSession.Token = _httpContextAccessor.HttpContext.Session.GetString("Token");

        //    Console.WriteLine($"User Info: {userSession.Token}");

            
        //    return Task.FromResult(userSession);
        //}


        public Task<bool> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserResponse>> GetAll()
        {
            var user = await _user.GetAll();
            var userDto = user.Adapt<List<UserResponse>>();

            return userDto;
        }

        public async Task<UserResponse> GetById(Guid id)
        {
            var user = await _user.GetById(id);


            var userDto = user?.Adapt<UserResponse>();

            return userDto;
        }


        public async Task<LoginResponse> UserLogin(LoginRequest request)
        {
            var employee = await _user.GetUserByEmpNumber(request.EmployeeNumber);
            if (employee == null)
            {
                return null;
            }

            if (request == null) return null;

            var user = await _context.User.FirstOrDefaultAsync(x => x.EmployeeNumber == request.EmployeeNumber);

            if (user == null) return null;

            if (!PasswordHasher.VerifyPassword(request.Password, user.Password))
                return null;

            var loginResponse = user.Adapt<LoginResponse>();

            // Check if the password is the temporary password
            loginResponse.IsTemporaryPassword = request.Password == "Temp_Password01";

            loginResponse.token = CreateJwt(user);

            return loginResponse;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> Update (Guid id, UpdateUserRequest request)
        {

            var employeeDetails = await _employeeDetailsRepository.GetByEmployee(request.EmployeeNumber);
            if (employeeDetails == null) return null;

            var user = await _user.GetById(id);

            if (user == null) return null;

            user.employeeDetails = employeeDetails;
            user.EmployeeId=employeeDetails.Id;
            user.employeeName = user.employeeName;
            user.Department = user.Department;
            user.Password= PasswordHasher.HashPassword(request.Password);

            await _user.SaveChangesAysnc();
            return user.Adapt<UserResponse>();
        }
        public async Task<UserResponse> RegisterUser(UserRequest request)
        {
            var employee = await _employeeDetailsRepository.GetByEmployee(request.EmployeeNumber);
            if (employee == null) return null;

            if (await CheckUserNameExist(request.EmployeeNumber))
            {
                // User with the given EmployeeNumber already exists
                return null; // or return a bad request message
            }

            var passMessage = CheckPasswordStrength("Temp_Password01");
            if (!string.IsNullOrEmpty(passMessage))
                return null;

            var user = request.Adapt<User>();
           
            user.EmployeeId = employee.Id;
            user.EmployeeNumber = employee.EmployeeNumber;
            user.employeeName = employee.FName + " " + employee.LName;
            user.Department = employee.Department;
            user.Password = PasswordHasher.HashPassword("Temp_Password01");
           

            _user.Add(user);

            await _user.SaveChangesAysnc();

            var userDto = user.Adapt<UserResponse>();
            return userDto;

        }

        private async Task<bool> CheckUserNameExist(int employeeNumber)
        {
            return await _context.User.AnyAsync(x => x.EmployeeNumber == employeeNumber);
        }


        private static string CheckPasswordStrength(string pass)
        {
            StringBuilder sb = new StringBuilder();
            if (pass.Length < 9)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[0-9]")))
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
            if (!Regex.IsMatch(pass, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                sb.Append("Password should contain special charcter" + Environment.NewLine);
            return sb.ToString();
        }

        private string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("b259c9a6f7b4dc09e5e36169f3e46c35e7dc776a10a14b609fc29e6eefb125c2");
            var identity = new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.Name, user.EmployeeNumber.ToString()),
                 new Claim(ClaimTypes.Role, user.userType)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var issuer_audience = "http//localhost:5041/";
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
                Issuer = issuer_audience,
                Audience = issuer_audience,

            };
            var token =  jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        public async Task<CheckLoggedResponse> CheckLogged(ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                var employeeNumbers = user.FindFirst(ClaimTypes.Name)?.Value;

                if (int.TryParse(employeeNumbers, out int employeeNumber))
                {
                    Console.WriteLine($"Logged-in user: {employeeNumber}");

                    // Retrieve additional user details using your user service
                    var userDetails = await _user.GetUserByEmpNumber(employeeNumber);

                    if (userDetails == null)
                    {
                        // Handle the case where user details are not found
                        Console.WriteLine("User details not found");
                        return new CheckLoggedResponse(); // Initialize an empty response or handle as needed
                    }

                    var empDetails = await _employeeDetailsRepository.GetById(userDetails.EmployeeId);

                    var checkLoggedResponse = userDetails.Adapt<CheckLoggedResponse>();
                    checkLoggedResponse.Department = empDetails.Department;
                    // Now you have the user details, proceed with your business logic
                    // You can return the user details or process them further

                    return checkLoggedResponse;
                }
            }

            return null; // Return null if user is not authenticated or if employee number is not valid
        }


    }
}
