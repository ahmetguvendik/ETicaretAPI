using System;
using ETicateAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.Users.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
		public CreateUserCommandHandler(UserManager<AppUser> userManager)
		{
            _userManager = userManager;
		}

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = new AppUser();
            user.Id = Guid.NewGuid().ToString();
            user.Email = request.Email;
            user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
           var identityResult =  await _userManager.CreateAsync(user,request.Password);
            if (identityResult.Succeeded)
            {
                return new CreateUserCommandResponse()
                {
                    isSucceced = identityResult.Succeeded,
                    Message = "Basarili"
                };
            }
            else
            {
                return new CreateUserCommandResponse()
                {
                    isSucceced = identityResult.Succeeded,
                    Message = "Basarili degil"
                };
            }
        }
    }
}

