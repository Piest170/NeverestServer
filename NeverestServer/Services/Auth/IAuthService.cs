using NeverestServer.Data.Dtos.User;
using NeverestServer.Models;

namespace NeverestServer.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string email, string username);
        Task<ServiceResponse<string>> Verify(string token);
        Task<ServiceResponse<string>> ForgotPassword(string email);
        Task<ServiceResponse<UserResetDto>> ResetPassword(UserResetDto reset);
    }
}
