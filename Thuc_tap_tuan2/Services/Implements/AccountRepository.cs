using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using Thuc_tap_tuan2.Dtos;
using Thuc_tap_tuan2.Entities;
using Thuc_tap_tuan2.Services.Interfaces;

namespace Thuc_tap_tuan2.Services.Implements
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager; 
        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager , IConfiguration configuration ,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager; 
            this.configuration = configuration;
            this.roleManager = roleManager ;


        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var passWordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passWordValid) 
            {
                return string.Empty;
            }
            var result = await signInManager.PasswordSignInAsync
                (model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email , model.Email),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())             
            };

            var userRole =await userManager.GetRolesAsync(user);
            foreach(var role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var authenKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]));

            var token = new JwtSecurityToken(
                issuer : configuration["Jwt:ValidIssuer"],
                audience : configuration["Jwt:ValidAudience"],
                expires : DateTime.Now.AddMinutes(30) , 
                claims : authClaims,
                signingCredentials : new SigningCredentials(authenKey , SecurityAlgorithms.HmacSha512Signature)

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        } 

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //kiem tra role 
                if(!await roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    await roleManager.CreateAsync(new IdentityRole (AppRole.Customer));    
                }
                await userManager.AddToRoleAsync(user, AppRole.Customer);  
            }
            return result; 
        }
    }
}
