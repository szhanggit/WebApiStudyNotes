using IdentityBasicEx.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityBasicEx.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<string> CreateToken();
    }
}
