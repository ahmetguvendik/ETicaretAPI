using System;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Features.Commands.Users.CreateUser;
using ETicaretAPI.Application.Services;
using ETicateAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicateAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            AppUser user = new AppUser();
            user.Id = Guid.NewGuid().ToString();
            user.Email = request.Email;
            user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            var identityResult = await _userManager.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {
                return new CreateUserResponse()
                {
                    isSucceced = identityResult.Succeeded,
                    Message = "Basarili"
                };
            }
            else
            {
                return new CreateUserResponse()
                {
                    isSucceced = identityResult.Succeeded,
                    Message = "Basarili degil"
                };
            }
        }
    }

    
}

