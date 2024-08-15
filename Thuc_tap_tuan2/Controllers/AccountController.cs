using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thuc_tap_tuan2.Dtos;
using Thuc_tap_tuan2.Services.Interfaces;

namespace Thuc_tap_tuan2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;
        public AccountController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        [HttpPost("SignUp")]
        public async Task <IActionResult> Signup(SignUpModel input)
        {
            try
            {
                var result = await accountRepo.SignUpAsync(input);


                return Ok(result.Succeeded);


            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }
        [HttpPost("Signin")]
        public async Task<IActionResult> SignIn(SignInModel input)
        {
            var reult = await accountRepo.SignInAsync(input);
            if (string.IsNullOrEmpty(reult))
            {
                return Unauthorized();
            }
            return Ok(reult);
        }
    }
}
