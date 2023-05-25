using System;
using ETicateAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.Users.SignInUser
{
	public class SignInUserCommandHandler : IRequestHandler<SignInUserCommandRequest,SignInUserCommandResponse>
	{
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public SignInUserCommandHandler(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }   
        public async Task<SignInUserCommandResponse> Handle(SignInUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if(user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                return new SignInUserCommandResponse()
                {
                    isSucceced = result.Succeeded,
                    Message = "Giris Yapildi"
                };
            }
            else
            {
                return new SignInUserCommandResponse()
                {
                    isSucceced = result.Succeeded,
                    Message = "Giris Yaparken Bir Hata Olustu"
                };
            }
        }
    }
}

