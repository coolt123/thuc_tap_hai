using Microsoft.AspNetCore.Identity;
using Thuc_tap_tuan2.Dtos;

namespace Thuc_tap_tuan2.Services.Interfaces
{
    public interface IAccountRepository
    {
         public Task<IdentityResult> SignUpAsync(SignUpModel model);
         public Task<String> SignInAsync(SignInModel model);
    }
}
