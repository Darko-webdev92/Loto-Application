using LotoApp.InterfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(Register model);
        Task<UserManagerResponse> LoginUserAsync(Login model);

    }
}
