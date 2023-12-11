using LotoApp.Models.Entities;
using LotoApp.Models.ViewModels;
using LotoApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LotoApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IConfiguration _configuration;
        private readonly JwtConfig _jwtConfig;

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IOptions<JwtConfig> jwtConfig,
             RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _jwtConfig = jwtConfig.Value;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "Email or Password is not correct",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Email or Password is not correct",
                    IsSuccess = false,
                };
            }
            var userRole = await _userManager.GetRolesAsync(user);
            IdentityOptions _options = new IdentityOptions();
            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, userRole.First())
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret));
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

                );
            string tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse(){
                Message = tokenHandler,
                IsSuccess=true,
                ExpireDate = token.ValidTo
            };
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
          if(model == null)
          {
                throw new NullReferenceException("Please fill the form");
          }

          if(model.Password != model.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };
                //throw new Exception("Passwords must match");
            }

            var user = new ApplicationUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleExist = await _roleManager.RoleExistsAsync("User");
                if (!roleExist)
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole("User"));

                }
                var addRole = await _userManager.AddToRoleAsync(user, "User");

                return new UserManagerResponse
                {
                    Message = "User created sucessfully",
                    IsSuccess = true,
                };
            }


            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        public string GenerateJwtToken(ApplicationUser model)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
           
            var tokenDescriptior = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name, $"{model.FirstName} {model.LastName}"),
                        new Claim(JwtRegisteredClaimNames.NameId, model.Id.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(3),
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }
    }
}
