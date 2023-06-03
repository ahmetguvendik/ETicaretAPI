using System;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Services;
using ETicateAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.Users.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
        private readonly IUserService _userService;
		public CreateUserCommandHandler(IUserService userService)
		{
            _userService = userService;
		}

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserRequest user = new()
            {
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName
            };

          var response =  await _userService.CreateUserAsync(user);
            if (response.isSucceced)
            {
                return new CreateUserCommandResponse()
                {
                    isSucceced = response.isSucceced,
                    Message =  response.Message
                };
            }
            else
            {
                return new CreateUserCommandResponse()
                {
                    isSucceced = response.isSucceced,
                    Message = response.Message
                };
            }
          
        }
    }
}

