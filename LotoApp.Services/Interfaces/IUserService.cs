using LotoApp.InterfaceModels;
using LotoApp.Models.ViewModels;

namespace LotoApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }
}
