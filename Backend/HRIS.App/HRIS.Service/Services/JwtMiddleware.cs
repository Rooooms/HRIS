//using Microsoft.AspNetCore.Http;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;

//namespace HRIS.Service.Services
//{
//    public class JwtMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly IConfiguration _configuration;
//        private readonly ILogger<JwtMiddleware> _logger;

//        public JwtMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<JwtMiddleware> logger)
//        {
//            _next = next;
//            _configuration = configuration;
//            _logger = logger;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//            _logger.LogInformation($"Received token: {token}");

//            var validationParameters = new TokenValidationParameters
//            {
//                ValidateActor = true,
//                ValidateIssuer = true,
//                ValidateAudience = true,
//                ValidateLifetime = true,
//                ValidateIssuerSigningKey = true,
//                ValidIssuer = _configuration["Jwt:Issuer"],
//                ValidAudience = _configuration["Jwt:Audience"],
//                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
//                ClockSkew = TimeSpan.FromMinutes(5)
//            };

//            try
//            {
//                if (token != null)
//                {
//                    // Validate and decode the JWT token here
//                    // For example, using JwtSecurityTokenHandler
//                    var tokenHandler = new JwtSecurityTokenHandler();
//                    var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

//                    // Set user claims in the HttpContext.User.Claims
//                    context.User = claimsPrincipal;
//                }
//            }
//            catch (SecurityTokenValidationException ex)
//            {
//                // Handle token validation errors (log, respond to the client, etc.)
//                // Log or respond with an appropriate error message
//                Console.WriteLine($"Token validation error: {ex.Message}");
//            }

            

//            await _next(context);
//        }
//    }
//}
