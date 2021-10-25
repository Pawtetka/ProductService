using Microsoft.AspNetCore.Identity;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Business.Services.Interfaces
{
    public interface ILoginService
    {
        Task<IdentityResult> Register(UserRegisterData userRegisterModel);
        Task<SignInResult> Login(UserLoginData userLoginModel);
        Task SignOut();
    }
}
