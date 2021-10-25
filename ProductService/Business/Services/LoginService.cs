using AutoMapper;
using ProductService.Data.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Models;
using ProductService.Data.Models;
using ProductService.Business.Services.Interfaces;

namespace ProductService.Business.Services
{
    public class LoginService : ILoginService
    {
        IUnitOfWork unit;
        IMapper _mapper;

        public LoginService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            unit = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SignInResult> Login(UserLoginData userLoginModel)
        {
            var res = await unit.SignInManager.PasswordSignInAsync(userLoginModel.Email, userLoginModel.Password, userLoginModel.RememberMe, false);
            return res;
        }

        public async Task<IdentityResult> Register(UserRegisterData userRegisterModel)
        {
            var user = _mapper.Map<User>(userRegisterModel);
            var res = await unit.UserManager.CreateAsync(user, userRegisterModel.Password);
            return res;
        }

        public async Task SignOut()
        {
            await unit.SignInManager.SignOutAsync();
        }
    }
}
