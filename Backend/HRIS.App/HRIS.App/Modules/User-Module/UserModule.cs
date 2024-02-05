using HRIS.Core.Interfaces.Services;
using HRIS.Core.Interfaces.Services.Leave_Service;
using HRIS.Core.Interfaces.Services.User_Service;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Requests.User_Request;
using HRIS.Service.Services.User_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HRIS.App.Modules.User_Module
{
    public static class UserModule
    {
        public static async void AddUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Users");

            group.MapGet("/", [Authorize] async (IUserService userService) => Results.Ok(await userService.GetAll()));

            group.MapPost("/", async (UserRequest request, IUserService userService) =>
            {

                if (request == null)
                {
                    return Results.BadRequest("Account already taken or exist");
                }

                var newUser = await userService.RegisterUser(request);
                return Results.Created($"api/Users/{newUser.Id}", newUser);
            });

            //group.MapPost("login", async (LoginRequest request, IUserService userService, HttpContext context) =>
            //{
            //    var result = await userService.LoginUser(request, context);

            //    if (result == null)
            //    {
            //        return Results.BadRequest("Invalid credentials");
            //    }

            //    // Use pattern matching to access tuple elements
            //    if (result.HasValue)
            //    {
            //        var (token, user) = result.Value;

            //        // Set session or handle user data as needed
            //        context.Session.SetString("UserId", user.Id.ToString());
            //        context.Session.SetString("employeeId", user.EmployeeId.ToString());
            //        context.Session.SetString("UserName", user.UserName);
            //        context.Session.SetString("employeeNumber", user.EmployeeNumber.ToString());
            //        context.Session.SetString("UserType", user.userType.ToString());            
            //        context.Session.SetString("Token", token);

            //        Console.WriteLine("Session Token", token);
            //        Console.WriteLine("Session User", user);



            //        return Results.Ok(new { Token = token });
            //    }
            //    else
            //    {
            //        // Handle the case when result is null (optional)
            //        return Results.BadRequest("Invalid credentials");
            //    }
            //});

            group.MapPost("login", async (LoginRequest request, IUserService usersService) =>
            {
                var loginResponse = await usersService.UserLogin(request);

                if (loginResponse == null)
                {
                    return Results.BadRequest("Invalid Account");
                }

                if (loginResponse != null)
                {
                    return Results.Ok(loginResponse);
                }
                else
                {
                    return Results.BadRequest("Incorrect password");
                }
            });

            group.MapGet("/check-logged", async (HttpContext context, IUserService userService) =>
            {
                var user = context.User;
                var checkLoggedResponse = await userService.CheckLogged(user);

                if (checkLoggedResponse != null)
                {
                    // User is authenticated, return relevant details
                    return Results.Ok(checkLoggedResponse);
                }
                else
                {
                    // User is not authenticated, return appropriate response
                    return Results.Unauthorized();
                }
            });




            //group.MapGet("checklogged",[Authorize] async (HttpContext context, IUserService usersService) =>
            //{
            //    var headers = context.Request.Headers;
            //    foreach (var header in headers)
            //    {
            //        Console.WriteLine($"Header: {header.Key}: {header.Value}");
            //    }
            //    var token = context.Session.GetString("Token");
            //    // Log or debug token
            //    Console.WriteLine($"Token from session: {token}");

            //    return Results.Ok(await usersService.CheckLogged());
            //});
            group.MapGet("logout", async (IUserService usersService) =>
            {
                await usersService.Logout();
                return Results.Ok();
            });

        }





    }
}
